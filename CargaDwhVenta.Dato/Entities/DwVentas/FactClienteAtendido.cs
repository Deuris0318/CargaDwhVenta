

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargaDwhVenta.Dato.Entities.DwVentas;

[Table("FactClienteAtendido", Schema = "dbo")]
public partial class FactClienteAtendido
{
    [Key]
    public int ClienteAtendidoId { get; set; }

    public int EmployeeKey { get; set; }

    public string? EmployeeName { get; set; }

    public int? TotalClientes { get; set; }
}