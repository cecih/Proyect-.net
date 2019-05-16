using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GastosApp.Models;

namespace GastosApp.Controllers
{
    public class GastosController : ApiController
    {

        Gastos[] gastos = new Gastos[]

        {
            new Gastos { Tipo = 1, Descripcion = "GASTO 1"},
            new Gastos { Tipo = 2, Descripcion = "GASTO 2" },
            new Gastos { Tipo = 3, Descripcion = "GASTO 3"}
        };
        
        
        // GET: api/Gastos
        public IEnumerable<Gastos> GetAllGastos()
        {
            return gastos;
        }

        // GET: api/Gastos/5
        public IHttpActionResult GetTipo(int tipo)
        {
            var gasto = gastos.FirstOrDefault((g) => g.Tipo == tipo);
            if (gasto == null)
                 return NotFound();


            return Ok(gasto);
        }

        // POST: api/Gastos
        public void PostGastos([FromBody]string value)
        {
            Gastos NGasto = new Gastos();

            Console.WriteLine("Ingrese un tipo: \n");
            NGasto.Tipo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la descripcion: \n");
            NGasto.Descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha: \n");
            NGasto.Fecha = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese el monto: \n");
            NGasto.Monto = Convert.ToDecimal(Console.ReadLine());
             
        }

        // PUT: api/Gastos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gastos/5
        public void Delete(int id)
        {
        }
    }
}
