using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public string  Identificacion_Cliente { get; set; }
        public string NombreCliente { get; set; }

        public int Edad { get; set; }
        public string Direccion { get; set; }
        public Int64 Telefono { get; set; }
        public int Id_Categoria { get; set; }
        public int Id_TipoIDentificacion { get; set; }

        public string Correo { get; set; }

    }
}
