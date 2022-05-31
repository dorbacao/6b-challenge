
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
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

        return builder.Services;
    }


    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking Services", Version = "v1" });
            options.ConfigureAreas();
            //options.ConfigureSwaggerSecuritySchema();

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
    public static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {

        services.AddControllers(options =>
        {

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