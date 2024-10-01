using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoWebApp.Models;

namespace UmbracoWebApp.Controllers;

public class ServiceSurfaceController : SurfaceController
{
    public ServiceSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
    }

    public IActionResult HandleSubmit(ServiceFormModel form)
    {
        if (!ModelState.IsValid)
        {
            ViewData["name"] = form.Name;
            ViewData["email"] = form.Email;
            ViewData["question"] = form.Question;

            ViewData["error_name"] = string.IsNullOrEmpty(form.Name);
            ViewData["error_email"] = string.IsNullOrEmpty(form.Email);
            ViewData["error_question"] = string.IsNullOrEmpty(form.Question);

            return CurrentUmbracoPage();
        }

        ViewData["success"] = "Thank You!";
        return CurrentUmbracoPage();
    }
}
