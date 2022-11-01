namespace Biblioteca.HttpApi.Controllers;
using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Dto;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
    private readonly ILibroAppService libroAppService;

    public LibroController(ILibroAppService LibroAppService)
    {
        this.libroAppService = libroAppService;
    }

    [HttpGet]
    public ICollection<LibroDto> GetAll()
    {

        return libroAppService.GetAll();
    }

    [HttpPost]
    public async Task<LibroDto> CreateAsync(LibroDto libro)
    {

        return await libroAppService.CreateAsync(libro);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, LibroDto libro)
    {

        await libroAppService.UpdateAsync(id, libro);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int LibroId)
    {

        return await libroAppService.DeleteAsync(LibroId);

    }
}