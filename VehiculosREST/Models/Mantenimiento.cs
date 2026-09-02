using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculosREST.Models;

public class Mantenimiento
{
    [Key]
    public int IdMantenimiento { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    [MaxLength(100)]
    public string Tipo { get; set; } = string.Empty;

    [MaxLength(250)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Costo { get; set; }

    [Required]
    public int Kilometraje { get; set; }

    public bool Estado { get; set; }

    [Required]
    public int IdVehiculo { get; set; }

    public Vehiculo? Vehiculo { get; set; }
}