using System.Collections.Generic;
using WebApiDb.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var products = new List<Product>
{
    new Product { ProductId = 1, Nome = "Banana", Preco = 4.6f, Quantidade = 7 },
    new Product { ProductId = 2, Nome = "Pera", Preco = 4.6f, Quantidade = 7 },
    new Product { ProductId = 3, Nome = "Maçã", Preco = 4.6f, Quantidade = 7 },
    new Product { ProductId = 4, Nome = "Melão", Preco = 4.6f, Quantidade = 7 }
};
var app = builder.Build();

app.MapGet("/", () =>
{
    var productService = app.Services.GetRequiredService<List<Product>>();
    return Results.Ok(productService);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
