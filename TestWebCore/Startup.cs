using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using TestWebCore.App_Code;

namespace TestWebCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            //ע��swagger Api�ĵ�
            services.AddSwaggerGen(x=> {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "TestWebApi",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://www.baidu.com"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "ZW",
                        Email = string.Empty,
                        Url = new Uri("https://www.baidu.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "���֤����",
                        Url = new Uri("https://www.baidu.com")
                    },

                });
                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
                var xmlPath = Path.Combine(basePath, "TestWebCore.xml");
                x.IncludeXmlComments(xmlPath,true);

               // x.OperationFilter<AuthTokenHeaderParameter>();

                x.OperationFilter<AddHeaderOperationFilter>("Authorizations", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id
                x.OperationFilter<AddResponseHeadersFilter>();
                x.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                x.OperationFilter<SecurityRequirementsOperationFilter>();
                // ��api���token����֤��
                //x.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                //{
                //    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                //    Name = "Authorization",//jwtĬ�ϵĲ�������
                //    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                //    Type = SecuritySchemeType.ApiKey
                //});
            });

            //ע��jwt
            services.AddScoped<GenerateJwt>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            #region jwt��֤
            //var jwtConfig = new JwtConfig();
            //Configuration.Bind("JwtConfig", jwtConfig);
            #region Token
            //services.AddSingleton<IMemoryCache>(factory =>
            //{
            //    var cache = new MemoryCache(new MemoryCacheOptions());
            //    return cache;
            //});
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());
                options.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());
                options.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());
            });
            #endregion

            #endregion

            #region CORS ����
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", policy =>
                {
                    policy.AllowAnyOrigin()//�����κ�Դ
                    .AllowAnyMethod()//�����κη�ʽ
                    .AllowAnyHeader()//�����κ�ͷ
                    .AllowCredentials();//����cookie
                });
                c.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:8083")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("authorization");
                });
            });
            #endregion

            //���cors ���� ���ÿ�����
            //services.AddCors(x =>
            //{
            //    x.AddPolicy("any", x1 =>
            //    {
            //        x1.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials();
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            #region TokenAuth
            app.UseMiddleware<TokenAuth>();
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseAuthentication();//jwt
          
        }
    }
}
