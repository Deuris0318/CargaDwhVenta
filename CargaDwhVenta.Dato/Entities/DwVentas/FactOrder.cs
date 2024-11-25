
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargaDwhVenta.Dato.Entities.DwVentas;

[Table("FactOrders", Schema="dbo")]
public partial class FactOrder
{
    [Key]
    public int OrderNumber { get; set; }

    public int? DateKey { get; set; }

    public int ProductKey { get; set; }

    public string? CustomerName { get; set; }

    public int EmployeeKey { get; set; }

    public string? EmpleyeeName { get; set; }

    public int ShipperKey { get; set; }

    public string? CompanyName { get; set; }

    public string? CustumerKey { get; set; }

    public string? City { get; set; }

    public int? Año { get; set; }

    public int? Mes { get; set; }

    public double? TotalVentas { get; set; }

    public int? CantidadVentas { get; set; }
}