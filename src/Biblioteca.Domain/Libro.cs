using System.ComponentModel.DataAnnotations;
namespace Biblioteca.Domain;

public class Libro
{
    [Required]
     [Key]
    public int LibroId{get;set;}
    [Required]
    public string TituloLibro{get;set;}

    public string? DescripcionLibro{get;set;}

    public virtual Autor AutorLibro{get;set;}
    [Required]
    public int AutorId {get;set;}

    public virtual Editorial EditorialLibro{get;set;}

    [Required]

    public int EditoriaId{get;set;}

}
