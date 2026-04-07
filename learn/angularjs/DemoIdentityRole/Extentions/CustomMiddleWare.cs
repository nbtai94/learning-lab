namespace DemoIdentityRole.Extentions
{

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }


    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Do something with the request
            Console.WriteLine("Custom middleware executing before next middleware.");

            await _next(context);

            // Do something with the response
            Console.WriteLine("Custom middleware executing after next middleware.");
        }
    }
}
