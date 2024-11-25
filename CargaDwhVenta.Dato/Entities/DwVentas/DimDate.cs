namespace CargaDwhVenta.Dato.Entities.DwVentas;


public partial class DimDate
{
    public int DateKey { get; set; }

    public int DateOrder { get; set; }

    public DateOnly? Date { get; set; }

    public string? DateName { get; set; }

    public int? Month { get; set; }

    public string? MonthName { get; set; }

    public int? Year { get; set; }

    public string? YearName { get; set; }
}