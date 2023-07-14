using Movie.Management.Api.Configuration;

namespace Movie.Management.Api
{
    public static class Program
    {
        private static WebApplicationBuilder _builder;
        private static WebApplication _app;

        private static void Main(string[] args)
        {
            _builder = WebApplication.CreateBuilder(args);

            
            ConfigureServices();

            _app = _builder.Build();

            ConfigureRequestsPipeline();

            _app.Run();
        }

        private static void ConfigureServices()
        {
            _builder.AddApiConfiguration();
            _builder.Logging.AddLog4Net("log4net.config");
            _builder.AddSwaggerConfiguration();
        }

        private static void ConfigureRequestsPipeline()
        {
            _app.UseApiConfiguration();

            _app.UseSwaggerConfiguration();
        }
    }
}