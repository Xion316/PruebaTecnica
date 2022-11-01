using Biblioteca.Domain;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Infraestructure.Repository;

public class AutorRepository : EfRepository<Autor>, IAutorRepository
{
    public AutorRepository(BibliotecaDbContext context) : base(context)
    {
    }
}
