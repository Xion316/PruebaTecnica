using Biblioteca.Application.Dto;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain;
namespace Biblioteca.Application.Services;

public class AutorAppService : IAutorAppService
{
        private readonly IAutorRepository repository;
        private readonly IUnitOfWork unitOfWork;

    public AutorAppService(IAutorRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<AutorDto> CreateAsync(AutorDto autorDto)
    {
          
        //Mapeo Dto => Entidad
        var autor = new Autor();
       
        autor.AutorId= autorDto.AutorId;
        
        //Persistencia objeto
        autor = await repository.AddAsync(autor);
        await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var autorCreado = new AutorDto();
        
        autorCreado.NombreAutor = autor.NombreAutor;
        autorCreado.AutorId = autor.AutorId;
        autorCreado.CiudadAutor=autor.CiudadAutor;
        autorCreado.PaisAutor=autor.PaisAutor;
        return autorCreado;
    }

    public async Task<bool> DeleteAsync(int AutorId)
    {
         var autor = await repository.GetByIdAsync(AutorId);
        if (autor == null){
            throw new ArgumentException($"La marca con el id: {AutorId}, no existe");
        }

        repository.Delete(autor);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<AutorDto> GetAll()
    {
          var autorList = repository.GetAll();

        var autorListDto =  from a in autorList
                            select new AutorDto(){
                                AutorId = a.AutorId,
                                NombreAutor=a.NombreAutor,
                                PaisAutor=a.PaisAutor,
                                CiudadAutor=a.CiudadAutor    
                            };

        return autorListDto.ToList();
    }

    public async Task UpdateAsync(int id, AutorDto autorDto)
    {
        var autor = await repository.GetByIdAsync(id);
        if (autor == null){
            throw new ArgumentException($"La marca con el id: {id}, no existe");
        }

        //Mapeo Dto => Entidad
    
        autor.AutorId = autorDto.AutorId;
      
        //Persistencia objeto
        await repository.UpdateAsync(autor);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
