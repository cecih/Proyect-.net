using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SubirArchivoModels
    {
        public string Confirmacion { get; set; }
        public Exception Error { get; set; }

        public void SubirArchivo(string ruta, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta); //guardamos el archivo en la ruta especificada
                this.Confirmacion = "Fichero Guardado";

            }

            catch (Exception ex)
            {
                this.Error = ex;
            }
        }

    }
}