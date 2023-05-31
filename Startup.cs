
using IoCdotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using SACFiscalIO.Application.Domain;
using SACFiscalIO.Application.Miscellaneous;
using SACFiscalIO.Application.Repository;
using SACFiscalIO.Application.ViewModel;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SACFiscalIO.Tributacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static string SecureKey { get; private set; }
        public static string ConnectionString { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfiguraAutomapper();

            //services.AddHostedService<ProcessarRegrasPDVWorker>();

            SecureKey = Configuration["SecurityKey"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "sacfiscal.io",
                            ValidAudience = "sacfiscal.io",
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                return Task.CompletedTask;
                            }
                        };
                    }
                );
            services.AddCors(options =>
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .Build();
                })
            );

            services.AddSwaggerGen(x =>
            {
                services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("api", new OpenApiInfo { Title = "Tributação SACFiscal.IO", Version = "1.0" });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    x.IncludeXmlComments(xmlPath);
                });
            });
            //services.AddApplicationInsightsTelemetry();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddApplicationInsightsTelemetry(Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
        }


        public static void ConfiguraAutomapper()
        {
            IoC.GetManager()
                .Bind<IAutomapperFacade>(implementation: typeof(AutomapperFacadeImpl), singletonInstance: true);

            IAutomapperFacade mapper = IoC.Resolve<IAutomapperFacade>();
            mapper.Define(new AutoMapper.MapperConfiguration(c =>
            {
                c.CreateMap<Usuario, UsuarioViewModel>();

            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SACFiscal.IO Tributação API"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
            });

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors("EnableCORS");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
