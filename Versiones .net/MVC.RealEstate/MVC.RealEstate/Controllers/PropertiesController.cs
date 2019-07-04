using System;
using System.Linq;
using System.Web.Mvc;
using MVC.RealEstate.WebUI.Models.Entities;
using MVC.RealEstate.WebUI.Repositories;

namespace MVC.RealEstate.WebUI.Controllers {
    public class PropertiesController : ControllerBase<Property>
    {
        public PropertiesController(): base(new PropertyRepository())
        {
        }

        public override Property GetEntityByID(long id)
        {
            return repository.FindBy(x => x.PropertyID == id).FirstOrDefault();
        }

        public ActionResult Search(String cityID)
        {
            if (!String.IsNullOrEmpty(cityID))
            {
                Int64 id = Convert.ToInt64(cityID);
                return View("Results", this.repository.FindBy(x => x.CityID == id).ToList());
            }
            return View();
        }
    }
}