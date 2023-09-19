

using Microsoft.Extensions.DependencyInjection;
using MVC_ComponenteCodeFirst.CrossCuting.Logging;
using MVC_ComponenteCodeFirst.Data;
using MVC_ComponenteCodeFirst.Services;
using MVC_ComponenteCodeFirst.Services.RepoByApi;
using MVC_ComponenteCodeFirst.Validadores.VComponente;
using MVC_ComponenteCodeFirst.Validadores.VOrdenador;
using NLog;
using Polly;
using Polly.Extensions.Http;

namespace MVC_ComponenteCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            LogManager.Setup().LoadConfigurationFromFile("/nlog.config");

            //builder.Services.AddSqlite<TiendaContext>("Data Source=Ordenador.db");
            builder.Services.AddSqlite<TiendaContext>
                (builder.Configuration.GetConnectionString("AppConnection"));
            builder.Services.AddScoped<IRepositorioComponente,RepositorioComponenteByApi>();
            builder.Services.AddSingleton<ILoggerManager,LoggerManager>();
            builder.Services.AddScoped<IRepositorioOrdenador, RepositorioOrdenadorByApi>();
            builder.Services.AddScoped<IValidadorComponente, ValidadorComponente>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoByApi>();
            builder.Services.AddScoped<IValidadorOrdenador, ValidadorOrdenador> ();

            //
            //var retryPolicy = GetRetryPolicy();
            var circuitBreakerPolicy = GetCircuitBreakerPolicy();

            builder.Services.AddHttpClient("MyHttpClient")
                .AddPolicyHandler(circuitBreakerPolicy);


            var app = builder.Build();
            //app.CreateDbIfNotExists();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 3, // Número de intentos antes de abrir el circuito
                    durationOfBreak: TimeSpan.FromSeconds(30) // Duración de la apertura del circuito en segundos
                );
        }
    }
}