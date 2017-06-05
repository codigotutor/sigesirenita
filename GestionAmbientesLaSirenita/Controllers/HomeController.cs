using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAmbientesLaSirenita.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message1 = "MAESTRÍA EN GERENCIA DE SISTEMAS DE INFORMACIÓN Y PROYECTOS TECNOLÓGICOS";

            ViewBag.Message2 = "PROPUESTA DE PROYECTO TECNOLÓGICO";

            ViewBag.Message3 = "El proyecto tiene como propósito crear un sistema de información para la gestión de ambientes " +
                            "productivos del predio la Sirenita, con el que se permitirá administrar los recursos de la finca, " +
                            "los inventarios, acceder a consultas de manuales y certificaciones y préstamos de medios " +
                            "audiovisuales, El sistema de información permitirá ubicar mediante un mapa los ambientes " +
                            "productivos y dentro de estos gestionar la información concerniente a este.Los ambientes " +
                            "productivos que se gestionarán son: Porcinos, Aves palmípedas, Camuros, Cunicultura, Aves de " +
                            "postura, Bovinos";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Proyecto Tecnológico desarrollado por:";

            return View();
        }


        public ActionResult Mapa()
        {
            ViewBag.Message = "Ver Mapa";

            return View();
        }


    }
}