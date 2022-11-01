using Biblioteca.Domain.Interfaces;
using Biblioteca.Infraestructure;
using Biblioteca.Infraestructure.Repository;
using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//dbcontext

builder.Services.AddScoped<BibliotecaDbContext>();



//autor

builder.Services.AddTransient<IAutorRepository, AutorRepository>();

builder.Services.AddTransient<IAutorAppService, AutorAppService>();



//editorial

builder.Services.AddTransient<IEditorialRepository, EditorialRepository>();

builder.Services.AddTransient<IEditorialAppService, EditorialAppService>();



//Libro

builder.Services.AddTransient<ILibroRepository, LibroRepository>();

builder.Services.AddTransient<ILibroAppService, LibroAppService>();

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
