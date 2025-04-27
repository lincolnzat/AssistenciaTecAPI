using AssistenciaTecnicaAPI.Models;
using AssistenciaTecnicaAPI.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AssistenciaTecDatabaseSettings>(builder.Configuration.GetSection("AssistenciaTecDatabase"));

builder.Services.AddSingleton<ServicosService>(); //Registrado como DI para dar suporte a injeção de construtor nas classes consumidoras.
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
        


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Assistência Técnica API",
        Description = "API em ASP.NET Core para administrar ordem de serviços.",
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

