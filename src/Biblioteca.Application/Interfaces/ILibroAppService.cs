using Biblioteca.Application.Dto;
namespace Biblioteca.Application.Interfaces;

public interface ILibroAppService
{
     ICollection<LibroDto> GetAll();

    Task<LibroDto> CreateAsync(LibroDto libro);

    Task UpdateAsync (int id, LibroDto libro);

    Task<bool> DeleteAsync(int LibroId);
}
