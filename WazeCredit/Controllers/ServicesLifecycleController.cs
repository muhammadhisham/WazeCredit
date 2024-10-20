using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WazeCredit.Models;
using WazeCredit.Models.Service;
using WazeCredit.Models.Service.ServicesLifetimeExamples;
using WazeCredit.Models.ViewModel;
using WazeCredit.Utility.AppSettingsClasses;

namespace WazeCredit.Controllers
{
    public class ServicesLifecycleController : Controller
    {
        SingletonService _singletonService;
        ScopedService _scopedService;
        TransientService _transientService;

        public ServicesLifecycleController(SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            _scopedService = scopedService;
            _singletonService = singletonService;
            _transientService = transientService;
        }
        public IActionResult Index()
        {
            var messages = new List<string>
            {
                HttpContext.Items["CustomMiddlewareSingleton"].ToString(),
                $"Singleton Controller - {_singletonService.GetGuid().ToString()}",
                HttpContext.Items["CustomMiddlewareScoped"].ToString(),
                $"Scoped Controller - {_scopedService.GetGuid().ToString()}",
                HttpContext.Items["CustomMiddlewareTransient"].ToString(),
                $"Transient Controller - {_transientService.GetGuid().ToString()}"

            };
            return View(messages);
            
        }
    }
}
