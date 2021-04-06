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
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PersonsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly PostgreSQL postgreSQL;

        public PersonsController(ILogger<PersonsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            postgreSQL = new PostgreSQL(_configuration);

        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> GetWeather()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        //[HttpPost("Insert")]
        //public ActionResult InsertPerson([FromBody] Person person)
        //{
        //    //Simple functionality to insert a record into a Postgresql database.
        //    postgreSQL.OpenConnection();
        //    postgreSQL.InsertPerson(person.Nombre, person.Apellido);
        //    return new JsonResult("Registro insertado");
        //}
        //[HttpGet("GetAllPeople")]
        //public JsonResult GetAllPeople()
        //{
        //    postgreSQL.OpenConnection();
        //    string serializedPeople = JsonConvert.SerializeObject(postgreSQL.GetAllPeople(), Formatting.Indented);
        //    return new JsonResult(serializedPeople);

        //}
        //[HttpGet("Delete/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    postgreSQL.OpenConnection();
        //    if (postgreSQL.DeletePerson(id))
        //        return new JsonResult("Registro Eliminado");
        //    else
        //        return new JsonResult("Falla eliminando registro");

        //}
    }
}
