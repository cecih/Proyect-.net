using MVC.RealEstate.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RealEstate.WebUI.Models.Entities
{
    public class Property : EntityBase
    {
        public Int64 PropertyID { get; set; }

        [Required]
        public String Title { get; set; }

        public Int32 TypeID { get; set; }

        [Required]
        public String Description { get; set; }

        public Decimal Price { get; set; }

        public Int32 PropertyTypeID { get; set; }

        public Boolean Featured { get; set; }

        public Boolean Published { get; set; }

        public String Address { get; set; }

        public Int64 CityID { get; set; }

        public Decimal Latitude { get; set; }

        public Decimal Longitude { get; set; }

        public Int64 AgencyID { get; set; }

        public virtual Type Type { get; set; }
    }
}