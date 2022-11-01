using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.Dto;

public class LibroDto
{
    [Required]
    public int LibroId{get;set;}
    [Required]
    public string? TituloLibro{get;set;}

    public string? DescripcionLibro{get;set;}

    [Required]
    public int AutorId {get;set;}

    [Required]

    public int EditoriaId{get;set;}
}
