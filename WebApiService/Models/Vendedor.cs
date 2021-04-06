using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public class Vendedor
    {
        public int Id_Vendedor { get; set; }
        public string CodigoVendedro { get; set; }
        public int Id_TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombre_Vendedor { get; set; }
    }
}
