using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VehiculosREST.Models;

public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(250)]
    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    [JsonIgnore]
    public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}