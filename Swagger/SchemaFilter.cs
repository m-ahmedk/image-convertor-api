using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ImageConvertorAPI.Swagger
{
    public class SwaggerSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(string) && schema.Description == "ImageFormat")
            {
                schema.Enum = new[]
                {
                    new OpenApiString("bmp"),
                    new OpenApiString("jpeg"),
                    new OpenApiString("jpg"),
                    new OpenApiString("png"),
                    new OpenApiString("gif"),
                    new OpenApiString("webp"),
                    new OpenApiString("tiff")
                };
            }
        }
    }
}