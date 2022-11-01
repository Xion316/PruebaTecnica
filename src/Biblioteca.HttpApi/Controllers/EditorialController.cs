namespace Biblioteca.HttpApi.Controllers;
using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Dto;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
    private readonly IEditorialAppService editorialAppService;

    public EditorialController(IEditorialAppService editorialAppService)
    {
        this.editorialAppService = editorialAppService;
    }

    [HttpGet]
    public ICollection<EditorialDto> GetAll()
    {

        return editorialAppService.GetAll();
    }

    [HttpPost]
    public async Task<EditorialDto> CreateAsync(EditorialDto editorial)
    {

        return await editorialAppService.CreateAsync(editorial);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, EditorialDto editorial)
    {

        await editorialAppService.UpdateAsync(id, editorial);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int EditorialId)
    {

        return await editorialAppService.DeleteAsync(EditorialId);

    }
}
