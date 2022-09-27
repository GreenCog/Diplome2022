using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Antitriche_diplome.models.ApiModels;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Antitriche_diplomebackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Antitriche_diplomebackContext") ?? throw new InvalidOperationException("Connection string 'Antitriche_diplomebackContext' not found.")));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.MaxDepth = 10;
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

});
builder.Services.AddDbContext<Antitriche_diplomebackContext>(opt =>
    opt.UseInMemoryDatabase("ResultatListe"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

app.UseHttpsRedirection();
app.UseCors("cors");
app.UseAuthorization();

app.MapControllers();

app.Run();
