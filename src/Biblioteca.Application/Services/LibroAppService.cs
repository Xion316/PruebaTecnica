using Biblioteca.Application.Dto;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain;
namespace Biblioteca.Application.Services;

public class LibroAppService : ILibroAppService
{
        private readonly ILibroRepository repository;
        private readonly IUnitOfWork unitOfWork;

    public LibroAppService(ILibroRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<LibroDto> CreateAsync(LibroDto libroDto)
    {
          
        //Mapeo Dto => Entidad
        var libro = new Libro();
        libro.LibroId = libroDto.LibroId;
        libro.DescripcionLibro=libroDto.DescripcionLibro;
        libro.AutorId=libroDto.AutorId;
        libro.EditoriaId=libroDto.EditoriaId;
 
        //Persistencia objeto
        libro = await repository.AddAsync(libro);
        await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var LibroCreado = new LibroDto();
        
        LibroCreado.TituloLibro = libro.TituloLibro;
        LibroCreado.LibroId = libro.LibroId;
        LibroCreado.DescripcionLibro=libro.DescripcionLibro;
        LibroCreado.AutorId=libro.AutorId;
        LibroCreado.EditoriaId=libro.EditoriaId;
        return LibroCreado;
    }

    public async Task<bool> DeleteAsync(int LibroId)
    {
         var libro = await repository.GetByIdAsync(LibroId);
        if (libro == null){
            throw new ArgumentException($"La marca con el id: {LibroId}, no existe");
        }

        repository.Delete(libro);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<LibroDto> GetAll()
    {
          var libroList = repository.GetAll();

        var libroListDto =  from l in libroList
                            select new LibroDto(){
                                LibroId = l.LibroId,
                                TituloLibro = l.TituloLibro,
                                DescripcionLibro=l.DescripcionLibro,
                                AutorId=l.AutorId,
                                EditoriaId=l.EditoriaId     
                            };

        return libroListDto.ToList();
    }

    public async Task UpdateAsync(int id, LibroDto libroDto)
    {
        var libro = await repository.GetByIdAsync(id);
        if (libro == null){
            throw new ArgumentException($"La marca con el id: {id}, no existe");
        }

        //Mapeo Dto => Entidad
        libro.LibroId = libroDto.LibroId;
        libro.DescripcionLibro=libroDto.DescripcionLibro;
        libro.AutorId=libroDto.AutorId;
        libro.EditoriaId=libroDto.EditoriaId;
        //Persistencia objeto
        await repository.UpdateAsync(libro);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
