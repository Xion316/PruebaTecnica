using Biblioteca.Domain;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Infraestructure.Repository;

public class LibroRepository : EfRepository<Libro>, ILibroRepository
{
    public LibroRepository(BibliotecaDbContext context) : base(context)
    {
    }
}
