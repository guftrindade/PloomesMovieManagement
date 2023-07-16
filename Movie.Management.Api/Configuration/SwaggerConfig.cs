using Microsoft.OpenApi.Models;
using System.Reflection;

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
                    Description = DESCRIPTION,
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Ferreira Trindade",
                        Email = "gustavoferreiratrindade@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/gustavoftrindade/")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);

                config.DocumentFilter<LowercaseDocumentFilter>();
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

        public const string DESCRIPTION = "Teste prático desenvolvido para o processo seletivo de Desenvolvedor C# Júnior - [Ploomes](https://www.ploomes.com/)." + 
                                          " Esta API trata-se de um gerenciamento de filmes, onde é possível fazer a inserção, listagem de todos os filmes com paginação e a busca" +
                                          " por um filme específico pelo ID, onde foi implementado um cache utilizando Redis, otimizando consultas no banco de dados. Caso tenha interesse em outros projetos, visite meu [GitHub](https://github.com/guftrindade).";
    }
}
