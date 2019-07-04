using MVC.RealEstate.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.RealEstate.WebUI.Models
{
    public class PropertiesResume
    {
        public List<Property> Properties { get; set; }

        [Required]
        public String CityID { get; set; }

        [Required]
        public String Description { get; set; }
    }
}