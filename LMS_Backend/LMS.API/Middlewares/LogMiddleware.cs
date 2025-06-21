
namespace LMS_Backend.LMS.API.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private const string LogFilePath = "logs.txt"; 
        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            DateTime requestTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{requestTime}] : {httpContext.Request.Method} : {httpContext.Request.Path}");

            await _next(httpContext);

            DateTime responseTime = DateTime.Now;
            int statusCode = httpContext.Response.StatusCode;

            switch (statusCode)
            {
                case >= 200 and < 300: Console.ForegroundColor = ConsoleColor.Green; break; // Success
                case >= 300 and < 400: Console.ForegroundColor = ConsoleColor.Yellow; break; // Redirection
                case >= 400 and < 500: Console.ForegroundColor = ConsoleColor.Red; break; // Client Error
                case >= 500 and < 600: Console.ForegroundColor = ConsoleColor.DarkRed; break; // Server Error
                default: Console.ForegroundColor = ConsoleColor.Gray; break;
            }

            // Log status to console
            Console.WriteLine($"[{responseTime}] : {statusCode}");

            // Reset Console Color
            Console.ResetColor();

            // Append log to file
            string logEntry = $"Request Time: {requestTime} | Response Time: {responseTime} | Status Code: {statusCode}{Environment.NewLine}";
            await File.AppendAllTextAsync(LogFilePath, logEntry);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
