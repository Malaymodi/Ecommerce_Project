using Ecommerce_Project_WebAPI.APIRequestModels;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ecommerce_Project_WebAPI.Models
{
    public class CustomerFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CreateUserRequestModel))
            {
                schema.Example = new OpenApiObject
                {
                    ["ClassNumber"] = new OpenApiString("2.6"),
                    //["ToDate"] = new OpenApiInteger(1)
                    //other property in your model
                };
            }
        }
    }
}
