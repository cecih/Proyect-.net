using MVC.RealEstate.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.RealEstate.WebUI.Dummies
{
    public class DummyManager
    {
        public static IQueryable<Property> GetProperties()
        {
            List<Property> list = new List<Property>();
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 2000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 60000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 90000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 100000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 551000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 551000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 551000));
            list.Add(Create(1, "ZEBALLOS 34232", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 2228", false, true, 1000));
            list.Add(Create(1, "ZEBALLOS 2228", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 34232", true, true, 1000));
            list.Add(Create(1, "ZEBALLOS 2228", "Departamento contrafrente, baño con bañera, cocina semiintegrada al estar comedor. Balcón al frente y balcon al contrafrente.",
                "ZEBALLOS 2228", true, false, 1000));

            return list.AsQueryable();
        }

        private static Property Create(int id, string title, string description, String address, bool featured, bool published, Decimal price)
        {
            var ad = new Property
                        {
                            PropertyID = id,
                            Title = title,
                            Description = description,
                            Address = address,
                            Featured = featured,
                            Published = published,
                            Price = price,
                            AgencyID = 1,
                        };
            return ad;
        }
    }
}