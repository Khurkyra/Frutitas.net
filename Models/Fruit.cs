using System.ComponentModel.DataAnnotations;

namespace Frutas.Models
{
    public class Fruit
    {
        [Key]
        public int Id { get; set; }  // Mapea la columna id (int)

        [Required]
        public string Nombre { get; set; }  // Mapea la columna nombre (nvarchar)
    }
}
