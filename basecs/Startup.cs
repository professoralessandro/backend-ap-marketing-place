using basecs.Business.Avaliacoes;
using basecs.Business.Bloqueios;
using basecs.Business.Caracteristicas;
using basecs.Business.Compras;
using basecs.Business.Configuracoes;
using basecs.Business.Produtos;
using basecs.Business.Telefones;
using basecs.Business.Usuarios;
using basecs.Data;
using basecs.Helpers.RumtimeStings;
using basecs.Interfaces.Business.AvaliacoesBusiness;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using basecs.Interfaces.Data;
using basecs.Interfaces.Repository;
using basecs.Interfaces.Services.IAvaliacoesService;
using basecs.Interfaces.Services.IBloqueiosService;
using basecs.Interfaces.Services.ICaracteristicasService;
using basecs.Interfaces.Services.IComprasService;
using basecs.Interfaces.Services.IConfiguracoesService;
using basecs.Interfaces.Services.ILogsService;
using basecs.Interfaces.Services.ITelefonesService;
using basecs.Interfaces.Services.IUsuariosService;
using basecs.Interfaces.Services.IWelcomeService;
using basecs.Repository.Usuarios;
using basecs.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            #region RUMTIME SETTINGS
            RumtimeSettings.ConnectionString = Configuration.GetValue<string>("ConnectionString").ToString();
            #endregion

            #region RUMTIME SETTINGS PAGSEGURO
            RumtimeStingsPagSeguro.Url = Configuration.GetValue<string>("MercadoPagoIntegration:Url").ToString();
            RumtimeStingsPagSeguro.Email = Configuration.GetValue<string>("MercadoPagoIntegration:Email").ToString();
            RumtimeStingsPagSeguro.Token = Configuration.GetValue<string>("MercadoPagoIntegration:Token").ToString();

            // MERCADO PAGO SETTINGS
            RumtimeStingsPagSeguro.CheckoutUrl = Configuration.GetValue<string>("MercadoPagoIntegration:CheckoutUrl").ToString();
            RumtimeStingsPagSeguro.CancelamentoUrl = Configuration.GetValue<string>("MercadoPagoIntegration:CancelamentoUrl").ToString();
            RumtimeStingsPagSeguro.ConsultaUrlUrl = Configuration.GetValue<string>("MercadoPagoIntegration:ConsultaUrl").ToString();
            RumtimeStingsPagSeguro.FinalizacaoUrl = Configuration.GetValue<string>("MercadoPagoIntegration:FinalizacaoUrl").ToString();
            #endregion

            #region CONFIGURATION SERVICES
            services.AddEntityFrameworkSqlServer().AddDbContext<MyDbContext>(a => a.UseSqlServer(RumtimeSettings.ConnectionString));
            services = Container(services);
            #endregion

            #region CONFIGURATION SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DEV - APP MKT Place", Version = "v1" });
            });
            #endregion

            services.AddControllers();
        }
        #endregion

        #region SERVICES CONTAINER METHOD
        private IServiceCollection Container(IServiceCollection services)
        {
            // DAPPER
            services.AddScoped<APDConnector>();
            services.AddTransient<IAPDWork, APDWork>();

            // SERVICES
            services.AddScoped<IAvaliacoesService, AvaliacoesService>();
            services.AddScoped<IBloqueiosService, BloqueiosService>();
            services.AddScoped<ICaracteristicasService, CaracteristicasService>();
            services.AddScoped<IComprasService, ComprasService>();
            services.AddScoped<IConfiguracoesService, ConfiguracoesService>();
            services.AddScoped<IWelcomeService, WelcomeService>();
            services.AddScoped<ILogsService, LogsService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IUsuariosService, UsuariosService>();
            services.AddScoped<ITelefonesService, TelefonesService>();

            // REPOSITORYS
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();

            // BUSSINESS
            services.AddScoped<IAvaliacoesBusiness, AvaliacoesBusiness>();
            services.AddScoped<IBloqueiosBusiness, BloqueiosBusiness>();
            services.AddScoped<ICaracteristicasBusiness, CaracteristicasBusiness>();
            services.AddScoped<IComprasBusiness, ComprasBusiness>();
            services.AddScoped<IConfiguracoesBusiness, ConfiguracoesBusiness>();
            services.AddScoped<IProdutosBusiness, ProdutosBusiness>();
            services.AddScoped<ITelefonesBusiness, TelefonesBusiness>();
            services.AddScoped<IUsuariosBusiness, UsuariosBusiness>();

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