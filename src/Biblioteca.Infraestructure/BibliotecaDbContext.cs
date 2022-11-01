using Biblioteca.Domain;
using Biblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infraestructure;

public class BibliotecaDbContext: DbContext, IUnitOfWork
{
    public DbSet<Autor> Autors { get; set; }

     public DbSet<Editorial> Editorials {get;set;}

     public DbSet<Libro> Libros{get;set;}

    public string DbPath { get; set; }

    public BibliotecaDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "biblioteca.v1.db");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
