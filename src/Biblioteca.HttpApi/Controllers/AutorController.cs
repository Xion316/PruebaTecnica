namespace Biblioteca.HttpApi.Controllers;
using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Dto;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
    private readonly IAutorAppService autorAppService;

    public AutorController(IAutorAppService autorAppService)
    {
        this.autorAppService = autorAppService;
    }

    [HttpGet]
    public ICollection<AutorDto> GetAll()
    {

        return autorAppService.GetAll();
    }

    [HttpPost]
    public async Task<AutorDto> CreateAsync(AutorDto autor)
    {

        return await autorAppService.CreateAsync(autor);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, AutorDto autor)
    {

        await autorAppService.UpdateAsync(id, autor);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int AutorId)
    {

        return await autorAppService.DeleteAsync(AutorId);

    }
}
