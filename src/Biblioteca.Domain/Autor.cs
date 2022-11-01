using System.ComponentModel.DataAnnotations;
namespace Biblioteca.Domain;

public class Autor
{
    [Required]
     [Key]
    public int AutorId{get;set;}
    public string NombreAutor{get;set;}
    public string PaisAutor{get;set;}
    public string CiudadAutor{get;set;}
}
