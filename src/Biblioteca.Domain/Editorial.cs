using System.ComponentModel.DataAnnotations;
namespace Biblioteca.Domain;

public class Editorial
{
    
    [Required]
    [Key]
    public int EditoriaId{get;set;}
    public string NombreEditorial{get;set;}
    public string PaisEditorial{get;set;}
    public string CiudadEditorial{get;set;}
}
