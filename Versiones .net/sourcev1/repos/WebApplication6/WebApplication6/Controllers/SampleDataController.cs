using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gastos.Controllers
{
    [Route("api/[controller]")]
    /*public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };*/

    public class GastosController : Controller
    {
        GastosDiarios[] gastos = new GastosDiarios[]
        {
            new GastosDiarios {Tipo = 1, Descripcion = "GASTO 1" },
            new GastosDiarios { Tipo = 2, Descripcion = "GASTO 2"},
            new GastosDiarios { Tipo = 3, Descripcion = "GASTO 3"}

        };
    }

    [HttpGet("{Tipo}")]
    /*public IEnumerable<WeatherForecast> WeatherForecasts()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        });
    }*/

    public IEnumerable<GastosDiarios> GetGastosDiarios()
    {
        return gastos;
    }

    
    [HttpPost]
    public as
    





    public class GastosDiarios
        {
             public DateTime Fecha { get; set; }
             public int Tipo  { get; set; }
             
             public string Descripcion { get; set; }
             public decimal Monto { get; set; }
        }
       /* public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }*/
    }
}
