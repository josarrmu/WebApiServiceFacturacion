using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public class DetalleFacturaDTO
    {
        public int Id_Detalle { get; set; }
        public int Id_Factura { get; set; }
        public int Id_Producto { get; set; }

        public int Catidad_Producto { get; set; }

        public decimal PrecioProducto { get; set; }
    }
}
