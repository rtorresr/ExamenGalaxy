using Examen.Manager;
using Examen.Manager.Clases;
using Examen.Manager.Interfaces;
using Examen.Services;
using Examen.Services.Clases;
using Examen.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Helper
{
    public static class Helper
    {
        public static void InyectaDependencias(this IServiceCollection services)
        {
            #region Services 

            services.AddTransient<ITipoArticuloServices, TipoArticuloServices>();
            services.AddTransient<IUserAppServices, UserAppServices>();
            services.AddTransient<IArticuloServices, ArticuloServices>();
            services.AddTransient<IOpcionServices, OpcionServices>();

            #endregion

            #region Manager

            services.AddTransient<ITipoArticuloManager, TipoArticuloManager>();
            services.AddTransient<IUsuarioManager, UsuarioManager>();
            services.AddTransient<IArticuloManager, ArticuloManager>();
            services.AddTransient<IOpcionManager, OpcionManager>();

            #endregion
        }

        public static void GestionExcepciones(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Sucedio un errror inesperado: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }

        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
