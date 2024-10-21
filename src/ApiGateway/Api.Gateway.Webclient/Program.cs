using Api.Gateway.Models;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Api.Gateway.Webclient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<ApiUrls>(options => builder.Configuration.GetSection("ApiUrls").Bind(options));
            
            var keyBytes = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:secretkey"]);

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // Define el esquema de seguridad
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autenticación JWT usando el esquema Bearer. \r\n\r\n Escribe 'Bearer' seguido de un espacio y luego tu token. \r\n\r\n Ejemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                                        {
                                            {
                                                new OpenApiSecurityScheme
                                                {
                                                    Reference = new OpenApiReference
                                                    {
                                                        Type = ReferenceType.SecurityScheme,
                                                        Id = "Bearer"
                                                    }
                                                },
                                                Array.Empty<string>()
                                            }
                                        });
            });


            builder.Services.AddHttpClient<ICatalogProxy, CatalogProxy>();
            builder.Services.AddHttpClient<IOrderProxy, OrderProxy>();
            builder.Services.AddHttpClient<IIdentityProxy, IdentityProxy>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
