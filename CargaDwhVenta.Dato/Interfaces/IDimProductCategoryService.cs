using CargaDwhVenta.Dato.Core;
using CargaDwhVenta.Dato.Entities.DwVentas;


namespace CargaDwhVenta.Dato.Interfaces
{
    public interface IDimProductCategoryService
    {

        Task<OperationResult> LoadDHW();
    }
}
