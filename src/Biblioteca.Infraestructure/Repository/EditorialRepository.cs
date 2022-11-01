using Biblioteca.Domain;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Infraestructure.Repository;

public class EditorialRepository : EfRepository<Editorial>, IEditorialRepository
{
    public EditorialRepository(BibliotecaDbContext context) : base(context)
    {
    }
}
