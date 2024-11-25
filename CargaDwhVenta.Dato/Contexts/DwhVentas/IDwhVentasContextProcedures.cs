
namespace cargaDwhVenta.ObjetoBaseDatos.Context
{
    public partial interface IDwhVentasContextProcedures
    {
        Task<int> CleanDataAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> LoadCustumersAsync(string CustumerName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> LoadDateAsync(int? DateOrder, DateOnly? Date, string DateName, int? Month, string MonthName, int? Year, string YearName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> LoadEmployeesAsync(string EmployeeName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> LoadFactClienteAtendidoAsync(int? EmployeesKey, string TotalClientes, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> LoadFactOrderAsync(int? DateKey, int? ProductKey, int? EmployeeKey, int? ShipperKey, int? CustumerKey, string City, decimal? TotalVentas, int? CantidadVentas, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> LoadShipperAsync(string CompanyName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> ProductCategoryAsync(int? ProductId, int? Category, string ProductName, string CategoryName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
