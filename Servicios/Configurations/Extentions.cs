using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Configurations
{
    public static class Extentions
    {
        #region ConfigureServices

        /// <summary>
        /// agrega los metodos necesarios para iniciar la documentacion con swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        { // REGISTRAMOS SWAGGER COMO SERVICIO
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Utilidades";
                    document.Info.Description = "API ";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "",
                        Email = "",
                        //Url = new Uri("https://twitter.com/spboyer"),
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "",
                        //Url = "https://example.com/license"
                    };
                };

            });
            return services;
        }

        /// <summary>
        /// agregan metodos de seguidad al api
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSegurity(this IServiceCollection services)
        {




            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)// allow any origin
                .AllowCredentials()
                .Build()
              );
            });
            return services;
        }
        #endregion
        #region Area Configuration
        /// <summary>
        /// Se agrega configuracion de la documentacion con swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            //AÑADIMOS EL MIDDLEWARE DE SWAGGER(NSwag)
            //app.UseOpenApi(); // serve documents (same as app.UseSwagger()) para  local
            app.UseOpenApi(a =>
            {
                a.PostProcess = (document, _) =>
                {
                    document.Schemes = new[] { OpenApiSchema.Https, OpenApiSchema.Http };
                };
            });

            app.UseSwaggerUi3(options =>
            {
                // Define web UI route
                options.Path = "/swagger";
            });


            app.UseReDoc(c =>
            {
                //c.Path = "/redoc";
                c.DocumentPath = "/swagger/v1/swagger.json";
            });

            return app;
        }


        #endregion
    }
}
