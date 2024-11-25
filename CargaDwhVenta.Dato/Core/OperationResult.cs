using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaDwhVenta.Dato.Core
{
    public class OperationResult
    {
        public dynamic? data { get; set; }
        public OperationResult()
        {
            this.Success = true;
        }
        public bool Success { get; set; }

        public string? message { get; set; }
    }
}
