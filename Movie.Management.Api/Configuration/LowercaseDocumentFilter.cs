using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Movie.Management.Api.Configuration
{
    public class LowercaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths.ToDictionary(entry => entry.Key.ToLowerInvariant(),
                entry => entry.Value);
            
            swaggerDoc.Paths.Clear();

            foreach (var (key, value) in paths)
            {
                swaggerDoc.Paths.Add(key, value);
            }
        }
    }
}
