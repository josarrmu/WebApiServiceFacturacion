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
    
    [Route("persons/detalleFactura")]
    public class DetalleFacturaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DetalleFacturaController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PostgreSQL postgreSQL;

        public DetalleFacturaController(ILogger<DetalleFacturaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            postgreSQL = new PostgreSQL(_configuration);

        }

        [HttpPost("InsertDetalleFactura")]
        public ActionResult InsertDetalleFactura([FromBody] DetalleFacturaDTO facturaDTO)
        {
            //Simple functionality to insert a record into a Postgresql database.

            postgreSQL.OpenConnection();
            postgreSQL.InsertDetalleFactura(facturaDTO);
            return new JsonResult("Registro insertado");
        }
        [HttpGet("GetDetalles")]
        public JsonResult GetAllDetalleFactura()
        {
            postgreSQL.OpenConnection();
            string serializedProduct = JsonConvert.SerializeObject(postgreSQL.GetDetalles(null), Formatting.Indented);
            return new JsonResult(serializedProduct);

        }
        [HttpGet("DeleteDetalleFactura/{id}")]
        public IActionResult Delete(int id)
        {
            postgreSQL.OpenConnection();
            if (postgreSQL.DeleteDetalleFactura(id))
                return new JsonResult("Registro Eliminado");
            else
                return new JsonResult("Falla eliminando registro");

        }

        [HttpPost("UpdateDetalleFactura")]
        public ActionResult UpdateDetalleFactura(DetalleFacturaDTO producto)
        {
            //Simple functionality to insert a record into a Postgresql database.
            postgreSQL.OpenConnection();
            postgreSQL.UpdateDetalleFactura(producto);
            if (postgreSQL.UpdateDetalleFactura(producto))
                return new JsonResult("Registro actualizado");
            else
                return new JsonResult("Falla actualizando registro");
        }
    }
}
