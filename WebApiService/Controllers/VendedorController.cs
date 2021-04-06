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
    
    [Route("persons/vendedor")]
    public class VendedorController : ControllerBase
    {
       

        private readonly ILogger<VendedorController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PostgreSQL postgreSQL;

        public VendedorController(ILogger<VendedorController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            postgreSQL = new PostgreSQL(_configuration);

        }


        [HttpPost("InsertVendedor")]
        public ActionResult InsertVendedor([FromBody] Vendedor vendedor)
        {
            //Simple functionality to insert a record into a Postgresql database.
            postgreSQL.OpenConnection();
            postgreSQL.InsertarVendedor(vendedor);
            return new JsonResult("Registro insertado");
        }
        [HttpGet("GetAllVendedores")]
        public JsonResult GetAllVendedorese()
        {
            postgreSQL.OpenConnection();
            string serializedPeople = JsonConvert.SerializeObject(postgreSQL.GetAllVendedores(null), Formatting.Indented);
            return new JsonResult(serializedPeople);

        }
        [HttpGet("DeleteVendedor/{id}")]
        public IActionResult DeleteVendedor(int id)
        {
            postgreSQL.OpenConnection();
            if (postgreSQL.DeleteVendedor(id))
                return new JsonResult("Registro Eliminado");
            else
                return new JsonResult("Falla eliminando registro");

        }
    }
}
