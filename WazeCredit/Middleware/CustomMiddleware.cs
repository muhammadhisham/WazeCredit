using WazeCredit.Models.Service.ServicesLifetimeExamples;

namespace WazeCredit.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            context.Items.Add("CustomMiddlewareSingleton", "Singleton Middlware - " + singletonService.GetGuid());
            context.Items.Add("CustomMiddlewareScoped", "Scoped Middlware - " + scopedService.GetGuid());
            context.Items.Add("CustomMiddlewareTransient", "Transient Middlware - " + transientService.GetGuid());
            await _next(context);
        }
    }
}
