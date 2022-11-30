using Microsoft.EntityFrameworkCore;
using ProductManagement_2;
using ProductManagement_2.Interfaces;
using ProductManagement_2.Mapping;
using ProductManagement_2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMapper<ProductManagement_2.Entities.Product, ProductManagement_2.Models.ProductModel>, ProductMapper>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMapper<ProductManagement_2.Entities.Category, ProductManagement_2.Models.CategoryModel>, CategoryMapper>();
builder.Services.AddDbContext<ProductManagmentContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagementDB_2")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<ProductManagmentContext>();
    dbContext.Database.Migrate();
}


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
