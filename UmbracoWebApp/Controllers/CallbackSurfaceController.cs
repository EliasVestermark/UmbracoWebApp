using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoWebApp.Models;

namespace UmbracoWebApp.Controllers;

public class CallbackSurfaceController : SurfaceController
{
    public CallbackSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
    }

    public IActionResult HandleSubmit(CallbackFormModel form)
    {
        if (!ModelState.IsValid)
        {
            ViewData["name"] = form.Name;
            ViewData["email"] = form.Email;
            ViewData["phone"] = form.Phone;

            ViewData["error_name"] = string.IsNullOrEmpty(form.Name);
            ViewData["error_email"] = string.IsNullOrEmpty(form.Email);
            ViewData["error_phone"] = string.IsNullOrEmpty(form.Phone);

            return CurrentUmbracoPage();
        }

        ViewData["success"] = "Thank You!";
        return CurrentUmbracoPage();
    }
}
