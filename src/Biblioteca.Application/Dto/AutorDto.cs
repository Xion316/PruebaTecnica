using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.Dto;

public class AutorDto
{
     [Required]
    public int AutorId{get;set;}
    public string? NombreAutor{get;set;}
    public string? PaisAutor{get;set;}
    public string? CiudadAutor{get;set;}
}

