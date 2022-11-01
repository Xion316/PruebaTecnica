using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.Dto;

public class EditorialDto
{
    [Required]
    public int EditoriaId{get;set;}
    public string? NombreEditorial{get;set;}
    public string? PaisEditorial{get;set;}
    public string? CiudadEditorial{get;set;}
}
