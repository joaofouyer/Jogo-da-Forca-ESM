using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JFESM.API;
using JFESM.Core;
using JFESM.Persistence;
using JFESM.Web.Options;
using JFESM.Web.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace JFESM.Web
{
    public partial class Startup {
        public IConfigurationRoot Configuration { get; }

        public Startup (IHostingEnvironment env) {
            var builder = new ConfigurationBuilder ()
                .SetBasePath (env.ContentRootPath)
                .AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true)
                .AddJsonFile ($"appsettings.{env.EnvironmentName}.json", optional : true)
                .AddEnvironmentVariables ();
            Configuration = builder.Build ();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // Add DbContext
            services.AddDbContext<JFESMContext> (o => o.UseInMemoryDatabase ("JFESM_Dev"));

            // Add framework services.
            services.AddMvc ().AddJsonOptions (
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Add application WebSocket Manager
            services.AddWebSocketManager ();
            // Add application servicesc
            services.AddTransient<ISalaService, SalaService> ();
            services.AddTransient<ISalaRepository, SalaRepository> ();
            services.Add (new ServiceDescriptor (typeof (ClientOptions), provider => BuildClientOptions (), ServiceLifetime.Singleton));

            services.Configure<JwtOptions> (o => {
                var options = BuildJwtOptions ();

                o.Issuer = options.Issuer;
                o.Audience = options.Audience;
                o.Authority = options.Authority;
                o.Expires = options.Expires;
                o.SigningCredentials = options.SigningCredentials;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole (Configuration.GetSection ("Logging"));
            loggerFactory.AddDebug ();

            ConfigureAuth (app);
            SeedDatabase (app);

            // TODO: Stricter CORS rules in Production
            app.UseCors (builder => {
                builder
                    .AllowAnyOrigin ()
                    .AllowAnyHeader ()
                    .AllowAnyMethod ();
            });
            app.UseFileServer ();
            var wsOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(60),
                ReceiveBufferSize = 4 * 1024
            };

            app.UseWebSockets(wsOptions);
            app.MapWebSocketManager("/sala", serviceProvider.GetService<RoomHandler>());
            app.UseMvc ();
        }

        private JwtOptions BuildJwtOptions () {
            var options = Configuration.GetSection ("JwtOptions");
            var signingKey = new SymmetricSecurityKey (Encoding.ASCII.GetBytes (options["Key"]));
            var signingCredentials = new SigningCredentials (signingKey, SecurityAlgorithms.HmacSha256);

            return new JwtOptions () {
                Issuer = options["Issuer"],
                    Audience = options["Audience"],
                    Authority = options["Authority"],
                    Expires = long.TryParse (options["ExpiresInHours"], out long expiresResult) ?
                    TimeSpan.FromHours (expiresResult) :
                    (TimeSpan?) null,
                    SigningCredentials = signingCredentials,
            };
        }

        private ClientOptions BuildClientOptions () {
            var options = Configuration.GetSection ("ClientOptions");
            return new ClientOptions () { ClientUrl = options["Url"] };
        }
    }
}