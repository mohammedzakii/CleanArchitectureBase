namespace CleanArchitectureBase.WebApi.Middlewares
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandling> _logger;

        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"Unhandled exception: {ex}");

                // Handle the exception (you can customize this part)
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }
    }
}
