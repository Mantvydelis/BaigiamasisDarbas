using MongoDB.Driver;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Repositories;
using Parduotuve.Core.Services;
using Serilog;
using Serilog.Events;



var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient("mongodb+srv://mantvydassemeta:Slaptazodis@cluster0.awg2t.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"));
builder.Services.AddTransient<IMongoDbCacheRepository, MongoDbCacheRepository>();

builder.Services.AddSingleton<ICacheService, CacheService>();


builder.Services.AddTransient<IProduktaiEFDBRepository, ProduktaiEFDBRepository>(_ => new ProduktaiEFDBRepository());
builder.Services.AddTransient<IProduktaiService, ProduktaiService>();

builder.Services.AddTransient<IVartotojaiEFDBRepository, VartotojaiEFDBRepository>(_ => new VartotojaiEFDBRepository());
builder.Services.AddTransient<IVartotojaiService, VartotojaiService>();

builder.Services.AddTransient<IUzsakymaiEFDBRepository, UzsakymaiEFDBRepository>(_ => new UzsakymaiEFDBRepository());
builder.Services.AddTransient<IUzsakymaiService, UzsakymaiService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
