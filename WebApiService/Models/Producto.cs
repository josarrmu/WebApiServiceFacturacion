using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public class Producto
    {
        public int Id_Producto { get; set; }

        public string Codigo_Producto { get; set; }

        public string Nombre_Producto { get; set; }
        public string Descripcion_Producto { get; set; }
        public int Cantidad_Stock { get; set; }
        public double Precio { get; set; }
        public int Id_Categoria { get; set; }
        public int Id_Proveedor { get; set; }
    }
}
