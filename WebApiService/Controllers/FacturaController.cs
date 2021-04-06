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
    
    [Route("persons/factura")]
    public class FacturaController : ControllerBase
    {
       

        private readonly ILogger<FacturaController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PostgreSQL postgreSQL;

        public FacturaController(ILogger<FacturaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            postgreSQL = new PostgreSQL(_configuration);

        }

        [HttpPost("InsertFactura")]
        public ActionResult InsertFactura([FromBody] FacturaDTO facturaDTO)
        {
            //Simple functionality to insert a record into a Postgresql database.

            postgreSQL.OpenConnection();
            postgreSQL.InsertarFactura(facturaDTO);
            return new JsonResult("Registro insertado");
        }
        [HttpGet("GetAllFacturas")]
        public JsonResult GetAllFacturas()
        {
            postgreSQL.OpenConnection();
            string serializedProduct = JsonConvert.SerializeObject(postgreSQL.GetFacturas(null), Formatting.Indented);
            return new JsonResult(serializedProduct);

        }
        [HttpGet("DeleteFactura/{id}")]
        public IActionResult Delete(int id)
        {
            postgreSQL.OpenConnection();
            if (postgreSQL.DeleteFactura(id))
                return new JsonResult("Registro Eliminado");
            else
                return new JsonResult("Falla eliminando registro");

        }

        [HttpPost("UpdateFactura")]
        public ActionResult UpdateFactura(FacturaDTO factura)
        {
            //Simple functionality to insert a record into a Postgresql database.
            postgreSQL.OpenConnection();
            //postgreSQL.UpdateFactura(factura);
            if (postgreSQL.UpdateFactura(factura))
                return new JsonResult("Registro actualizado");
            else
                return new JsonResult("Falla actualizando registro");
        }

       
    }
}
