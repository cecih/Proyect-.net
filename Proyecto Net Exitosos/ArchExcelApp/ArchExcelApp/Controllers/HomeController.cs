using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArchExcelApp.Models;
using LinqToExcel;
/*using System.Data;
 using System.Data.OleDb;
 using System.Data.SqlClient;
 librerias que se usan para conectar a servidor sql y transmitir datos*/

//Paso 3
namespace ArchExcelApp.Controllers
{
    public class HomeController : Controller
    {
        //Metodo que lee y parsea el archivo excel
        public List<EntidadHojaExcel> ToEntidadHojaExcelList(string pathDelFicheroExcel)
        {
            var book = new ExcelQueryFactory(pathDelFicheroExcel); //estamos buscando la ubicacion del archivo
            var resultado = (from row in book.Worksheet("Hoja1") //tomamos la 1erHoja
                             let item = new EntidadHojaExcel
                             {
                                 Id = row["Id"].ToString(),
                                 Nombre = row["Nombre"].ToString(),
                                 Apellido = row["Apellido"].ToString()
                             }
                             select item).ToList();

            book.Dispose(); //cierra y libera la conexion con el archivo
            return resultado; //devolvemos el resultado
        }

        //Paso 5
        /*public void CopiarASql(string pathDelFicheroExcel)
        {
            string Source = Server.MapPath(pathDelFicheroExcel); //ruta para el archivo excel a Copiar
            //establecemos una conexion a un SQL Server
            string conexion = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Source +"; Extended Properties=\"Excel 8.0; HDR=Yes\"";

            OleDbConnection origen = default(OleDbConnection);
            origen = new OleDbConnection(conexion); //generamos la conexion

            OleDbCommand seleccion = default(OleDbCommand);
            seleccion = new OleDbCommand("Select * From [Hoja1$]", origen); //tomamos los datos

            OleDbDataAdapter adaptador = new OleDbDataAdapter();
            adaptador.SelectCommand = seleccion;

            DataSet ds = new DataSet();

            adaptador.Fill(ds); // completamos con los datos del archivo en la tabla de sql

            origen.Close(); //cerramos la conexion

            //conectamos con un SqlClient
            SqlConnection conexion_destino = new SqlConnection();
            conexion_destino.ConnectionString = "Data Source=.;Initial Catalog=DBExcel; Integrated Security = True";

            conexion_destino.Open(); //abrimos conexion

            SqlBulkCopy importar = default(SqlBulkCopy);
            importar = new SqlBulkCopy(conexion_destino);
            importar.DestinationTableName = "Tabla_Usuario"; //importamos a la tabla los datos del excel
            importar.WriteToServer(ds.Tables[0]); //escribimos en el servidor los datos de la 1erHoja
            conexion_destino.Close(); //cerramos conexion con el servidor
        }*/



        public ActionResult Index()
        {

            //get the selected radio value
            string file = Request.Params["file"]; 
            //string worksheet = Request.Params["worksheet"];

            //initialize list
            IEnumerable<EntidadHojaExcel> list = new List<EntidadHojaExcel>();
            if (file != null && file != "") //chqueamos que no se haya ingresado contenido vacio
            {
                //Get Server Path of Excel file
                string fileSrc;
                //vemos el value de nombre file 
                if (file == "0")
                {
                    fileSrc = Server.MapPath("~/Content/Files/GenBetaDev.xlsx");
                    //call the first Method
                    list = ToEntidadHojaExcelList(fileSrc);
                    //CopiarASql(fileSrc);
                }
                else
                {
                    fileSrc = Server.MapPath("~/Content/Files/BetaDev.xlsx");
                    //call the second Method
                    list = ToEntidadHojaExcelList(fileSrc);
                    //CopiarASql(fileSrc);
                }
            }
            //return list as Enumerable to our model
            return View(list); //devolvemos la lista elegida

        }

    }
    }

