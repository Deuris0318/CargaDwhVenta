
using cargaDwhVenta.ObjetoBaseDatos.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CargaDwhVenta.Dato.Contexts
{
    public partial class DwhVentasContext 
    {
        private IDwhVentasContextProcedures _procedures;

        public virtual IDwhVentasContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new DwhVentasContextProcedures (this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IDwhVentasContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public partial class DwhVentasContextProcedures : IDwhVentasContextProcedures
    {
        private readonly DwhVentasContext _context;

        public DwhVentasContextProcedures(DwhVentasContext context)
        {
            _context = context;
        }

        public  async Task<int> CleanDataAsync(OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[CleanData]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public  async Task<int> LoadCustumersAsync(string CustumerName, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "CustumerName",
                    Size = 200,
                    Value = CustumerName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[LoadCustumers] @CustumerName = @CustumerName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public  async Task<int> LoadDateAsync(int? DateOrder, DateOnly? Date, string DateName, int? Month, string MonthName, int? Year, string YearName, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "DateOrder",
                    Value = DateOrder ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Date",
                    Value = Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "DateName",
                    Size = 50,
                    Value = DateName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Month",
                    Value = Month ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "MonthName",
                    Size = 50,
                    Value = MonthName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Year",
                    Value = Year ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "YearName",
                    Size = 50,
                    Value = YearName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[LoadDate] @DateOrder = @DateOrder, @Date = @Date, @DateName = @DateName, @Month = @Month, @MonthName = @MonthName, @Year = @Year, @YearName = @YearName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public  async Task<int> LoadEmployeesAsync(string EmployeeName, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "EmployeeName",
                    Size = 200,
                    Value = EmployeeName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[LoadEmployees] @EmployeeName = @EmployeeName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public  async Task<int> LoadFactClienteAtendidoAsync(int? EmployeesKey, string TotalClientes, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "EmployeesKey",
                    Value = EmployeesKey ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "TotalClientes",
                    Size = 10,
                    Value = TotalClientes ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[LoadFactClienteAtendido] @EmployeesKey = @EmployeesKey, @TotalClientes = @TotalClientes", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public  async Task<int> LoadFactOrderAsync(int? DateKey, int? ProductKey, int? EmployeeKey, int? ShipperKey, int? CustumerKey, string City, decimal? TotalVentas, int? CantidadVentas, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "DateKey",
                    Value = DateKey ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "ProductKey",
                    Value = ProductKey ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "EmployeeKey",
                    Value = EmployeeKey ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "ShipperKey",
                    Value = ShipperKey ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "CustumerKey",
                    Value = CustumerKey ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "City",
                    Size = 50,
                    Value = City ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "TotalVentas",
                    Precision = 18,
                    Scale = 2,
                    Value = TotalVentas ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "CantidadVentas",
                    Value = CantidadVentas ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[LoadFactOrder] @DateKey = @DateKey, @ProductKey = @ProductKey, @EmployeeKey = @EmployeeKey, @ShipperKey = @ShipperKey, @CustumerKey = @CustumerKey, @City = @City, @TotalVentas = @TotalVentas, @CantidadVentas = @CantidadVentas", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public  async Task<int> LoadShipperAsync(string CompanyName, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "CompanyName",
                    Size = 40,
                    Value = CompanyName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[LoadShipper] @CompanyName = @CompanyName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public  async Task<int> ProductCategoryAsync(int? ProductId, int? Category, string ProductName, string CategoryName, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ProductId",
                    Value = ProductId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Category",
                    Value = Category ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "ProductName",
                    Size = 50,
                    Value = ProductName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "CategoryName",
                    Size = 50,
                    Value = CategoryName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[ProductCategory] @ProductId = @ProductId, @Category = @Category, @ProductName = @ProductName, @CategoryName = @CategoryName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
