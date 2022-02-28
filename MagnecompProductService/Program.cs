using MagnecompProductService.Data;
using MagnecompProductService.SyncDataServices.Http;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ### START: STREAM I.T. CONSULTING ###
if (builder.Environment.IsProduction())
{
  Console.WriteLine("--> Using SQL Server Database");
  builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductsConn")));
}
else
{
  Console.WriteLine("--> Using InMemory Database");
  builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDb"));
}
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
// ### END: STREAM I.T. CONSULTING ###

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine($"--> CommandService Endpoint {builder.Configuration["CommandService"]}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ### START: STREAM I.T. CONSULTING ###
PrepDb.PrepPopulation(app, builder.Environment.IsProduction());
// ### END: STREAM I.T. CONSULTING ###

app.Run();
