using Biblioteca.Application.Dto;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain;
namespace Biblioteca.Application.Services;

public class EditorialAppService : IEditorialAppService
{
        private readonly IEditorialRepository repository;
        private readonly IUnitOfWork unitOfWork;

    public EditorialAppService(IEditorialRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<EditorialDto> CreateAsync(EditorialDto editorialDto)
    {
          
        //Mapeo Dto => Entidad
        var editorial = new Editorial();
     
        editorial.EditoriaId = editorialDto.EditoriaId;
    
 
        //Persistencia objeto
        editorial = await repository.AddAsync(editorial);
        await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var editorialCreado = new EditorialDto();
        
        editorialCreado.NombreEditorial = editorial.NombreEditorial;
        editorialCreado.EditoriaId = editorial.EditoriaId;
        editorialCreado.CiudadEditorial=editorial.CiudadEditorial;
        editorialCreado.PaisEditorial=editorial.PaisEditorial;
        return editorialCreado;
    }

    public async Task<bool> DeleteAsync(int EditorialId)
    {
         var editorial = await repository.GetByIdAsync(EditorialId);
        if (editorial == null){
            throw new ArgumentException($"La marca con el id: {EditorialId}, no existe");
        }

        repository.Delete(editorial);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<EditorialDto> GetAll()
    {
          var EditorialList = repository.GetAll();

        var EditorialListDto =  from a in EditorialList
                            select new EditorialDto(){
                                EditoriaId = a.EditoriaId,
                                NombreEditorial=a.NombreEditorial,
                                PaisEditorial=a.PaisEditorial,
                                CiudadEditorial=a.CiudadEditorial    
                            };

        return EditorialListDto.ToList();
    }

    public async Task UpdateAsync(int id, EditorialDto editorialDto)
    {
        var editorial = await repository.GetByIdAsync(id);
        if (editorial == null){
            throw new ArgumentException($"La marca con el id: {id}, no existe");
        }

        //Mapeo Dto => Entidad
  
        editorial.EditoriaId = editorialDto.EditoriaId;
  
        //Persistencia objeto
        await repository.UpdateAsync(editorial);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
