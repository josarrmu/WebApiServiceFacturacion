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
    
    [Route("persons/cliente")]
    public class ClienteController : ControllerBase
    {
       

        private readonly ILogger<ClienteController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PostgreSQL postgreSQL;

        public ClienteController(ILogger<ClienteController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            postgreSQL = new PostgreSQL(_configuration);

        }

        
        [HttpPost("InsertarCliente")]
        public ActionResult InsertCliente([FromBody] Cliente cliente)
        {
            //Simple functionality to insert a record into a Postgresql database.
            postgreSQL.OpenConnection();
            postgreSQL.InsertarCliente(cliente);
            return new JsonResult("Registro insertado");
        }
        [HttpGet("GetAllClientes")]
        public JsonResult GetAllCliente()
        {
            postgreSQL.OpenConnection();
            string serializedPeople = JsonConvert.SerializeObject(postgreSQL.GetAllClientes(null), Formatting.Indented);
            return new JsonResult(serializedPeople);

        }
        [HttpGet("DeleteCliente/{id}")]
        public IActionResult Delete(int id)
        {
            postgreSQL.OpenConnection();
            if (postgreSQL.DeleteCliente(id))
                return new JsonResult("Registro Eliminado");
            else
                return new JsonResult("Falla eliminando registro");

        }
    }
}
