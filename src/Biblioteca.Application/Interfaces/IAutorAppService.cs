using Biblioteca.Application.Dto;
namespace Biblioteca.Application.Interfaces;

public interface IAutorAppService
{
     ICollection<AutorDto> GetAll();

    Task<AutorDto> CreateAsync(AutorDto autor);

    Task UpdateAsync (int id, AutorDto autor);

    Task<bool> DeleteAsync(int AutorId);
}
