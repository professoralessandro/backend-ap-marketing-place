using basecs.Data;
using basecs.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace basecs
{
    public class Startup
    {
        #region CLASS ATTRIBITES
        public IConfiguration Configuration { get; }
        #endregion

        #region CONSTRUCTORS
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region CONFIGURE SERVICES METHOD
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region CONFIGURATION SERVICES
            services.AddEntityFrameworkSqlServer().AddDbContext<MyDbContext>(a => a.UseSqlServer(Configuration.GetValue<String>("ConnectionString").ToString()));
            services = Container(services);
            #endregion

            #region CONFIGURATION SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APP MKT Place", Version = "v1" });
            });
            #endregion

            services.AddControllers();
        }
        #endregion

        #region SERVICES CONTAINER METHOD
        private IServiceCollection Container(IServiceCollection services)
        {
            services.AddScoped<TiposBloqueiosService>();
            services.AddScoped<TiposCaracteristicasService>();
            services.AddScoped<TiposConfiguracoesService>();
            services.AddScoped<TiposDadosService>();
            services.AddScoped<TiposDocumentosService>();
            services.AddScoped<TiposEmailsService>();
            services.AddScoped<TiposEnderecosService>();
            services.AddScoped<TiposLancamentosService>();
            services.AddScoped<TiposNotasFiscaisService>();
            services.AddScoped<TiposParametrosService>();
            services.AddScoped<TiposTelefonesService>();
            services.AddScoped<TiposWorkFlowsService>();
            services.AddScoped<WelcomeService>();
            services.AddScoped<LogsService>();
            
            return services;
        }
        #endregion

        #region CONFIGURE APP HTTPS REQUESTS METHOD
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region CONFIGURATION ENVRONMENT
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }
            #endregion

            #region CONFIGURATION SWAGGER
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APP MKT Place V1"));
            #endregion

            app.UseRouting();

            #region CONFIGURARION CORS
            app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}