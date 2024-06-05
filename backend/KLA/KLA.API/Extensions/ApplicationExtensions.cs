namespace KLA.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder AddApplicationExtentions(this IApplicationBuilder app)
        {
            app.UseHttpLogging();
            app.UseCors(options => options.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .WithOrigins("http://localhost:5173")
                                    .AllowCredentials());
            return app;
        }

    }
}
