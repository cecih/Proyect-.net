using MVC.RealEstate.WebUI.Models;
using MVC.RealEstate.WebUI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.RealEstate.WebUI.Controllers
{

    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Greeting = "Bienvenido";
            PropertiesResume propertiesResume = new PropertiesResume();
            var repository = new PropertyRepository();
            propertiesResume.Properties = repository.GetAll().Take(9).ToList();
            return View(propertiesResume);
        }
    }
}
