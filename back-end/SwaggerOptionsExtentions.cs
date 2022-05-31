
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SixB_Api.Infraestructure.Aspnetcore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;
using System.Reflection;
using System.Text;

public static class SwaggerOptionsExtentions
{
    public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<BookingDataContextFactory>();
        builder.Services.AddScoped<BookingDataContext>(serviceProvider => serviceProvider.GetRequiredService<BookingDataContextFactory>().CreateDbContext(null));

        builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

        return builder.Services;
    }


    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking Services", Version = "v1" });
            options.ConfigureAreas();
            options.ConfigureSwaggerSecuritySchema();

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    {
        async Task TokenValidatedAsync(TokenValidatedContext context)
        {
            var principal = context.Principal;

            await Task.FromResult(0);
        }

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("D596AE4BCD5AEE3EE5BCE1C95BC0BB69687DB0AE6714652288FA5C60DE79CBB5DBE5BBA0D548264B2FBDB80D0A0A16364ED0EC4728707203B310524A6D50EF9B")),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            };
            options.Events = new JwtBearerEvents();
            options.Events.OnTokenValidated = TokenValidatedAsync;
        });


        return services;
    }

    public static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {

        var policy = new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build();

        services.AddControllers(options =>
        {
            options.Filters.Add(new AuthorizeFilter(policy));

        }).AddNewtonsoftJson(opt =>
        {
            opt.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            opt.SerializerSettings.Culture = new CultureInfo("pt-PT");
            opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        })
                   ;

        return services;
    }

    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder
                                  .WithOrigins(
                                      "http://localhost:9080")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  ;
                              });
        });

        return services;
    }

    public static void ConfigureSwaggerSecuritySchema(this SwaggerGenOptions options)
    {
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
            Scheme = "bearer",
            BearerFormat = "JWT",
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Description = "Put only your token in text box. Don't put 'Bearer' initial string",

            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });

    }

    public static void ConfigureAreas(this SwaggerGenOptions c)
    {
        c.TagActionsBy(api =>
        {
            if (api.GroupName != null)
            {
                return new[] { api.GroupName };
            }

            var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                return new[] { controllerActionDescriptor.ControllerName };
            }

            throw new InvalidOperationException("Unable to determine tag for endpoint.");
        });

        c.DocInclusionPredicate((name, api) => true);
    }


}