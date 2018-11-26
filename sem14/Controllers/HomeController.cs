using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sem14.Models;
using sem14.Repositorio;

namespace sem14.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        AlumnoRepo alumrepository = new AlumnoRepo();
        public ActionResult Index()
        {
            ViewBag.Idcategoria = new SelectList(alumrepository.GetEmpModels., "IdCategoria", "NombreCategoria");
            return View();
        }
    }
}