using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VehiculosREST.Models;

public class Vehiculo
{
    [Key]
    public int IdVehiculo { get; set; }

    [Required]
    [MaxLength(20)]
    public string Placa { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Marca { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Modelo { get; set; } = string.Empty;

    [Required]
    public int Anio { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Precio { get; set; }

    public bool Estado { get; set; }

    [Required]
    public int IdCategoria { get; set; }

    public Categoria? Categoria { get; set; }

    [JsonIgnore]
    public ICollection<Mantenimiento> Mantenimientos { get; set; } =
        new List<Mantenimiento>();
}