using Microsoft.OpenApi.Models;

namespace Movie.Management.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ploomes Movie Management API",
                    Description = "Teste prático desenvolvido para o processo seletivo da Ploomes.",
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Trindade",
                        Email = "gustavo@dev.com"
                    }
                });
            });

            return builder;
        }

        public static WebApplication UseSwaggerConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            return app;
        }
    }
}
