using Autofac.Core;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Infrastructure;
using DNDCatalog.Infrastructure.Data;
using DNDCatalog.UnitTests;
using DNDCatalog.Web;
using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DNDCatalog.FunctionalTests;

public class DNDCatalogAPIApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private const string _environment = "Development";

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_environment); 
        var host = builder.Build();
        host.Start();

        var services = host.Services;

        using (var scope = services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var logger = scopedServices.GetRequiredService<ILogger<DNDCatalogAPIApplicationFactory<TStartup>>>();

            try
            {
                var db = scopedServices.GetRequiredService<CatalogDbContext>();
                db.Database.EnsureCreated();
                FakeData.PopulateData(db);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the " +
                                    "database with test messages. Error: {exceptionMessage}", ex.Message);
            }
        }

        return host;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CatalogDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // This should be set for each individual test run
                string inMemoryCollectionName = Guid.NewGuid().ToString();

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<CatalogDbContext>(options =>
                {
                    options.UseInMemoryDatabase(inMemoryCollectionName);
                });

                services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = MockJwtToken.SecurityKey,

                        SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                        {
                            JwtSecurityToken jwt = new JwtSecurityToken(token);

                            return jwt;
                        },
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = false,
                    };
                    options.Audience = MockJwtToken.Audience;
                    options.Authority = MockJwtToken.Issuer;
                    options.Configuration = new Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration()
                    {
                        Issuer = MockJwtToken.Issuer,
                    };
                });

            });
    }

}
