using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using szachy_online.Api.Data;
using szachy_online.Api.Hubs;
using szachy_online.Api.Services;
using szachy_online.Api.Settings;

namespace szachy_online.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options => {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                  policy => {
                      policy.WithOrigins("http://localhost:7225", "http://25.51.198.141:7225", "http://localhost:3000", "http://25.51.198.141:3000")
                .AllowAnyHeader()
                .WithMethods("GET","POST")
                .AllowAnyMethod()
                .AllowCredentials();
                  });
            });

            builder.Services.AddControllers();

            builder.Services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var tokenOptions = builder.Configuration
              .GetSection(TokenOptions.CONFIG_NAME)
              .Get<TokenOptions>();
            builder.Services.Configure<TokenOptions>(
              builder.Configuration.GetSection(TokenOptions.CONFIG_NAME)
            );

            builder.Services
              .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(
                o => {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromMinutes(1),
                        IgnoreTrailingSlashWhenValidatingAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(tokenOptions.SigningKey)
                  ),
                        ValidateIssuerSigningKey = tokenOptions.ValidateSigningKey,
                        RequireExpirationTime = true,
                        RequireAudience = true,
                        RequireSignedTokens = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidAudience = tokenOptions.Audience,
                        ValidIssuer = tokenOptions.Issuer
                    };
                    o.SaveToken = true;
                }
              );

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<AccountService>();
            builder.Services.AddScoped<GameService>();

            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChessHub>("/chesshub");
                endpoints.MapHub<InvitationHub>("/invHub");
            });



            app.Run();
        }
    }
}