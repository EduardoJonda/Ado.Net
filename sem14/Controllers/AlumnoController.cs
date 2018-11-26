using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sem14.Models;
using sem14.Repositorio;

namespace sem14.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno listado
        public ActionResult Index()
        {
            AlumnoRepo alumrepository = new AlumnoRepo();
            ModelState.Clear();
            return View(alumrepository.GetEmpModels());
        }

        // GET: Alumno/Details/5
        public ActionResult Details(string id)
        {
            AlumnoRepo alumrepository = new AlumnoRepo();
            return View(alumrepository.GetEmpModels().Find(Alm => Alm.codalu == id));
        }

        // GET: Alumno/Edit/5
        [HttpPost]
        public ActionResult Details(int id, AlumnoModel obj)
        {
            try
            {
                AlumnoRepo alumrepository = new AlumnoRepo();
                alumrepository.UpdateAlumnosModels(obj);
                return RedirectToAction("Index");
            }

            catch (Exception)
            {
                return View();
            }
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(AlumnoModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlumnoRepo alumrepository = new AlumnoRepo();
                    if (alumrepository.AddAlumnos(obj))
                    {
                        ViewBag.message = "Almacenado correctamente";
                    }

                }
                return View("Good");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(string id)
        {
            AlumnoRepo alumrepository = new AlumnoRepo();
            return View(alumrepository.GetEmpModels().Find(Alm => Alm.codalu == id));
        }

        // POST: Alumno/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, AlumnoModel obj)
        {
            AlumnoRepo alumrepository = new AlumnoRepo();
            alumrepository.DeleteAlumnodelete(obj.codalu);
            return View("Good");
        }
    }
}
