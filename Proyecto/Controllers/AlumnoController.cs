using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class AlumnoController : Controller
    {
        DaoAlumno dao = new DaoAlumno();
        // GET: Alumno
        public ActionResult Index()
        {
            IEnumerable<Alumno> lista = new List<Alumno>();
            lista = dao.listado();
            return View(lista);
        }
        public ActionResult Nuevo() { return View(); }
        public ActionResult insertar(Alumno al)
        {
            string msj = dao.guardar(al);
            if (msj == "listo")
            {
                ViewBag.mensaje = "Transaccion Exitosa";
            }
            return View("Nuevo", al);
        }
    }
}