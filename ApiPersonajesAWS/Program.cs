using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corsenabled", options =>
{
    options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Add services to the contai

string connectionString = builder.Configuration.GetConnectionString("MysqlTelevision");
builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddDbContext<PersonajesContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Api Personajes AWS",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aoi Personajes AWS");
    options.RoutePrefix = ""; //Mostrar la pagina inicial de la documentacion
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseCors("corsenabled");

app.UseAuthorization();

app.MapControllers();

app.Run();
