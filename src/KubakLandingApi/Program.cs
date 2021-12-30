using KubakLandingApi.Models;
using KubakLandingApi.Repo;
using MongoDB.Bson.Serialization.Conventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IViewCounterRepo, ViewCounterRepo>();

builder.Services
                .AddOptions<DatabaseSettings>()
                .Bind(builder.Configuration.GetSection(nameof(DatabaseSettings)))
                .ValidateDataAnnotations();

var conventionPack = new ConventionPack
{
    new IgnoreIfNullConvention(true),
    new CamelCaseElementNameConvention(),
    new IgnoreExtraElementsConvention(true)
};

ConventionRegistry.Register("default", conventionPack, t => true);


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
