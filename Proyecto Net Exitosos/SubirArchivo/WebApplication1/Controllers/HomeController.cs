using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        //Metodo Get para la vista SubirArchivo
        public ActionResult SubirArchivo()
        {
            return View(); //devuelvo la vista SubirArchivo
        }

        //Metodo Post para SubirArchivo
        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase file)
        {
            SubirArchivoModels modelo = new SubirArchivoModels();
            if (file != null)
            {
                String ruta = Server.MapPath("~/App_Data/"); //ruta en la que se guarda el archivo
                ruta += file.FileName; //se agrega
                modelo.SubirArchivo(ruta, file); //llamo al metodo del modelo para subir el archivo
                ViewBag.Error = modelo.Error;
                ViewBag.Confirmacion = modelo.Confirmacion;
            }

            return View(); //devuelvo la vista SubirArchivo
        }
    }
}