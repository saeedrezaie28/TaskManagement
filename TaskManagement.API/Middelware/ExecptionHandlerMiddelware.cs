
namespace TaskManagement.API.Middelware
{
    public class ExecptionHandlerMiddelware : IMiddleware
    {
        public ExecptionHandlerMiddelware()
        {
            
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
