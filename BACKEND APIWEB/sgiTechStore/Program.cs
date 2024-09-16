using Microsoft.EntityFrameworkCore;
using sgiTechStore.Interfaces;
using sgiTechStore.Models;
using sgiTechStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
         "MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICategoria, CategoriaService>();
builder.Services.AddScoped<IProducto, ProductoService>();
builder.Services.AddScoped<IProdXCat, ProdXCatService>();
builder.Services.AddDbContext<SgiTechStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("MyAllowSpecificOrigins");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
