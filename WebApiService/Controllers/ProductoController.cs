using DockerTest1.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiService.Models;

namespace WebApiService.Controllers
{
    
    [Route("persons/producto")]
    public class ProductoController : ControllerBase
    {
       

        private readonly ILogger<ProductoController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PostgreSQL postgreSQL;

        public ProductoController(ILogger<ProductoController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            postgreSQL = new PostgreSQL(_configuration);

        }

        [HttpPost("InsertarProducto")]
        public ActionResult InsertProducto([FromBody] Producto producto)
        {
            //Simple functionality to insert a record into a Postgresql database.
            postgreSQL.OpenConnection();
            postgreSQL.InsertProducto(producto);
            return new JsonResult("Registro insertado");
        }
        [HttpGet("GetAllProductos")]
        public JsonResult GetAllProductos()
        {
            postgreSQL.OpenConnection();
            string serializedPeople = JsonConvert.SerializeObject(postgreSQL.GetProductos(null), Formatting.Indented);
            return new JsonResult(serializedPeople);

        }
        [HttpGet("DeleteProducto/{id}")]
        public IActionResult DeleteProducto(int id)
        {
            postgreSQL.OpenConnection();
            if (postgreSQL.DeleteProducto(id))
                return new JsonResult("Registro Eliminado");
            else
                return new JsonResult("Falla eliminando registro");

        }

        [HttpPost("UpdateProducto")]
        public ActionResult UpdateProducto(Producto producto)
        {
            //Simple functionality to insert a record into a Postgresql database.
            postgreSQL.OpenConnection();
            //postgreSQL.UpdateProducto(producto);
            if (postgreSQL.UpdateProducto(producto))
                return new JsonResult("Registro actualizado");
            else
                return new JsonResult("Falla actualizando registro");
        }


    }
}
