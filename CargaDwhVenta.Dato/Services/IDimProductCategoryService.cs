using CargaDwhVenta.Dato.Contexts;
using CargaDwhVenta.Dato.Core;
using CargaDwhVenta.Dato.Entities.BDSales;
using CargaDwhVenta.Dato.Entities.DwVentas;
using CargaDwhVenta.Dato.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CargaDwhVenta.Dato.Services
{
    public class DimProductCategoryService: IDimProductCategoryService
    {
        private readonly BDSalesContext _bdSalessContext;
        private readonly DwhVentasContext _dwhVentasContext;

        public DimProductCategoryService(DwhVentasContext _dwhVentasContext, 
                                         BDSalesContext _bdSalessContext) 
        {
            this._dwhVentasContext = _dwhVentasContext;
            this._bdSalessContext = _bdSalessContext;
        }

        public async Task<OperationResult> LoadDHW()
        {
            OperationResult result = new OperationResult();
            try
            {
                await LoadDimEmployee();
                // await LoadDimProductCategory();
                // await LoadDimCustomers();
                // await LoadDimShippers();
                // await LoadFactSales();
                // await LoadFactCustomerServed();
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.message = $"Error cargando el DWH Ventas. {ex.Message}";
            }  return result;
        }

        private async Task<OperationResult> LoadDimEmployee()
        {
            OperationResult result = new OperationResult();

            try
            {

                int[] employeeId = await _dwhVentasContext.DimEmployees.Select(cd => cd.EmployeeKey).ToArrayAsync();

                if (employeeId.Any())
                {
                    await _dwhVentasContext.DimEmployees.Where(cd => employeeId.Contains(cd.EmployeeKey))
                        .AsNoTracking()
                        .ExecuteDeleteAsync();
                }

                //Obtener los empleados de la base de datos de norwind.
                var employees = await _bdSalessContext.Employees.AsNoTracking().Select(emp => new DimEmployee()
                {

                    EmployeeKey = emp.EmployeeId,
                    EmployeeName = string.Concat(emp.FirstName, " ", emp.LastName)
                }).ToListAsync();




                // Carga la dimension de empleados.
                await _dwhVentasContext.DimEmployees.AddRangeAsync(employees);
                await _dwhVentasContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.message = $"Error cargando la dimension de empleado {ex.Message}";
            }


            return result;
        }

        private async Task<OperationResult> LoadDimProductCategory()
        {
            OperationResult result = new OperationResult();
            try
            {

                int[] productId = await _dwhVentasContext.DimProductCategories.Select(cd => cd.ProductKey).ToArrayAsync();

                if (productId.Any())
                {
                    await _dwhVentasContext.DimProductCategories.Where(cd => productId.Contains(cd.ProductKey))
                        .AsNoTracking()
                        .ExecuteDeleteAsync();
                }

                // Obtener las products categories de norwind //
                var productCategories = await (from product in _bdSalessContext.Products
                                               join category in _bdSalessContext.Categories on product.CategoryId equals category.CategoryId
                                               select new DimProductCategory()
                                               {
                                                   CategoryId = category.CategoryId,
                                                   ProductName = product.ProductName,
                                                   CategoryName = category.CategoryName,
                                                   ProductId = product.ProductId
                                               }).AsNoTracking().ToListAsync();


                // Carga la dimension de Products Categories.
                await _dwhVentasContext.DimProductCategories.AddRangeAsync(productCategories);
                await _dwhVentasContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.message = $"Error cargando la dimension de producto y categoria. {ex.Message}";
            }
            return result;
        }

        private async Task<OperationResult> LoadDimCustomers()
        {
            OperationResult operaction = new OperationResult() { Success = false };


            try
            {
                int[] customerId = await _dwhVentasContext.DimCustumers.Select(cd => cd.CustomerKey).ToArrayAsync();

                if (customerId.Any())
                {
                    await _dwhVentasContext.DimCustumers.Where(cd => customerId.Contains(cd.CustomerKey))
                        .AsNoTracking()
                        .ExecuteDeleteAsync();
      
                }

                // Obtener clientes de norwind
                var customers = await _bdSalessContext.Customers.Select(cust => new DimCustumer()
                {
                    CustomerId = cust.CustomerId,
                    CustumerName = cust.CompanyName

                }).AsNoTracking()
                  .ToListAsync();

                // Carga dimension de cliente.
                await _dwhVentasContext.DimCustumers.AddRangeAsync(customers);
                await _dwhVentasContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                operaction.Success = false;
                operaction.message = $"Error: {ex.Message} cargando la dimension de clientes.";
            }
            return operaction;
        }

        private async Task<OperationResult> LoadDimShippers()
        {
            OperationResult result = new OperationResult();

            try
            {

                int[] ShipperId = await _dwhVentasContext.DimShippers.Select(cd => cd.ShipperKey).ToArrayAsync();

                if (ShipperId.Any())
                {
                    await _dwhVentasContext.DimShippers.Where(cd => ShipperId.Contains(cd.ShipperKey))
                        .AsNoTracking()
                        .ExecuteDeleteAsync();

                }

                var shippers = await _bdSalessContext.Shippers.Select(ship => new DimShipper()
                {
                    ShipperId = ship.ShipperID,
                    ShipperName = ship.CompanyName
                }).ToListAsync();


                await _dwhVentasContext.DimShippers.AddRangeAsync(shippers);
                await _dwhVentasContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.message = $"Error cargando la dimension de shippers {ex.Message} ";
            }
            return result;
        }

        private async Task<OperationResult> LoadFactSales()
        {
            OperationResult result = new OperationResult();

            try
            {
                var ventas = await _bdSalessContext.Vwventas.AsNoTracking().ToListAsync();

                int[] ordersId = await _dwhVentasContext.FactOrders.Select(cd => cd.OrderNumber).ToArrayAsync();

                if (ordersId.Any())
                {
                    await _dwhVentasContext.FactOrders.Where(cd => ordersId.Contains(cd.OrderNumber))
                        .AsNoTracking()
                        .ExecuteDeleteAsync();
                }

                foreach (var venta in ventas)
                {

                    FactOrder factOrder = new FactOrder()
                    {

                        City = venta.City,
                        CustumerKey = venta.CustomerId,
                        CustomerName = venta.CustomerName,
                        EmployeeKey = venta.EmployeeId,
                        ProductKey = venta.ProductID,
                        EmpleyeeName = venta.EmpleyeeName,
                        CompanyName = venta.CompanyName,
                        DateKey = venta.Datekey,
                        ShipperKey = venta.ShipperId,
                        TotalVentas = venta.TotalVentas,
                        Mes = venta.Año,
                        Año = venta.Mes,
                        CantidadVentas = venta.Cantidad
                    };

                    await _dwhVentasContext.FactOrders.AddAsync(factOrder);
                    await _dwhVentasContext.SaveChangesAsync();

                };



            }
            catch (Exception ex)
            {

                result.Success = false;
                result.message = $"Error cargando el fact de ventas {ex.Message} ";
            }

            return result;
        }
        
        private async Task<OperationResult> LoadFactCustomerServed()
        {
            OperationResult result = new OperationResult() { Success = true };

            try
            {
                var ventas = await _bdSalessContext.ViewClientesAtendidosPorEmpleados.AsNoTracking().ToListAsync();

                int[] ClienId = await _dwhVentasContext.FactClienteAtendidos.Select(cd => cd.ClienteAtendidoId).ToArrayAsync();

                if (ClienId.Any())
                {
                    await _dwhVentasContext.FactClienteAtendidos.Where(cd => ClienId.Contains(cd.ClienteAtendidoId))
                        .AsNoTracking()
                        .ExecuteDeleteAsync();
                }

                foreach (var venta in ventas)
                {

                    FactClienteAtendido factClienteAtendido = new FactClienteAtendido()
                    {

                        TotalClientes = venta.NumeroClientes,
                        EmployeeKey = venta.EmployeeId,
                        EmployeeName = venta.Empleado,

                    };

                    await _dwhVentasContext.FactClienteAtendidos.AddAsync(factClienteAtendido);
                    await _dwhVentasContext.SaveChangesAsync();

                };
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.message = $"Error cargando el fact de clientes atendidos {ex.Message} ";
            }
            return result;
        }
    }

}
