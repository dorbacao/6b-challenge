using SixB_Api.Infraestructure.Aspnetcore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureControllers();
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureSwagger();
builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();


// global cors policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.UseSwagger();

app.MapSwagger();

app.UseSwaggerUI();

app.Run();
