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
        [WebMethod(Description = "Consulta los libros disponibles")]
        public List<Libros> ObtenerLibros()
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                var Obtener = from c in db.Libros select c;
                return Obtener.ToList();
            }
        }

        [WebMethod(Description = "Agrega nuevos libros")]
        public string InsertarLibros(string titulo, string autor, int precio, string añoPublicaión)
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                Libros oLibro = new Libros();
                oLibro.Titulo = titulo;
                oLibro.Autor = autor;
                oLibro.Precio = precio;
                oLibro.AñoPublicacion = añoPublicaión;

                db.Libros.Add(oLibro);
                db.SaveChanges();

                return "Se ha guardado";
            }
        }

        [WebMethod(Description = "Modifica los libros")]
        public string ModificarLibros(int id, string titulo, string autor, int precio, string añoPublicaión)
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                var oLibro = (from c in db.Libros where c.Id == id select c).FirstOrDefault();
                
                if(oLibro != null)
                {
                    oLibro.Titulo = titulo;
                    oLibro.Autor = autor;
                    oLibro.Precio = precio;
                    oLibro.AñoPublicacion = añoPublicaión;

                    db.SaveChanges();

                    return "Se modificó";
                }
                return "No se encontró elemento";
            }
        }
        
        [WebMethod(Description = "Elimina los libros")]
        public string EliminarLibros(int id)
        {
            using (LibrosDBEntities db = new LibrosDBEntities())
            {
                var oLibro = (from c in db.Libros where c.Id == id select c).FirstOrDefault();

                if (oLibro != null)
                {
                    db.Libros.Remove(oLibro);
                    db.SaveChanges();

                    return "Se Eliminó";
                }
                return "No se encontró elemento";
            }
        }
    }
}
