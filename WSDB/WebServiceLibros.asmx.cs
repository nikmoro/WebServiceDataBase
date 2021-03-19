using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSDB.Model;

namespace WSDB
{
    /// <summary>
    /// Descripción breve de WebServiceLibros
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceLibros : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hola a todos";
        //}

        [WebMethod]
        public List<Libros> ObtenerLibros()
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                var Obtener = from c in db.Libros select c;
                return Obtener.ToList();
            }
        }

        [WebMethod]
        public string InsertarLibros(/*int id,*/ string titulo, string autor, int precio, string anio)
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                Libros oLibro = new Libros();
                oLibro.Titulo = titulo;
                oLibro.Autor = autor;
                oLibro.Precio = precio;
                oLibro.AñoPublicacion = anio;

                db.Libros.Add(oLibro);
                db.SaveChanges();

                return "Se ha guardado";
            }
        }
    }
}
