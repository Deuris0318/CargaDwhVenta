namespace CargaDwhVenta.Dato.Entities.DwVentas;


public partial class DimProductCategory
{
    public int ProductKey { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? CategoryName { get; set; }
}