using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebCore.App_Code
{
    public class AuthTokenHeaderParameter: IOperationFilter
    {


        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters = operation.Parameters ?? new List<OpenApiParameter>();
            //operation.Parameters = operation.Parameters ?? new List<IParameter>();
            //MemberAuthorizeAttribute 自定义的身份验证特性标记
            var isAuthor = operation != null && context != null;
            if (isAuthor)
            {
                //in query header "header"
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header, //query formData ..
                    Description = "身份验证",
                    Required = false,
                     
                });
            }
        }
    }
}
