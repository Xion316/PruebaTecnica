using Biblioteca.Application.Dto;
namespace Biblioteca.Application.Interfaces;

public interface IEditorialAppService
{
     ICollection<EditorialDto> GetAll();

    Task<EditorialDto> CreateAsync(EditorialDto editorial);

    Task UpdateAsync (int id, EditorialDto editorial);

    Task<bool> DeleteAsync(int EditoriaId);
}
