using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public class FacturaDTO
    {
        public int Id_Factura { get; set; }
        public string Codigo_Factura { get; set; }
        public int Id_Cliente { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int Id_EstadoFactura { get; set; }
        public int Id_MedioPago { get; set; }
        public int Id_Vendedor { get; set; }

        public List<DetalleFacturaDTO> Detalle_Facturas { get; set; }
    }
}
