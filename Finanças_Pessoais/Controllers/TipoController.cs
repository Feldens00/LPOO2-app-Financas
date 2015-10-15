using Finanças_Pessoais.Models;
using FinancasConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finanças_Pessoais.Controllers
{
    public class TipoController : Controller
    {
        DataBase database = new DataBase();
        TipoRepositorio tipRep = new TipoRepositorio();
        // GET: Tipo
        public ActionResult Tipo()
        {
            var tipo = tipRep.getAll();
            return View(tipo);
        }

        [HttpGet]
        public ActionResult CreateTipo()
        {
            
           
            return View();
        }

        [HttpPost]
        public ActionResult CreateTipo(Tipo tipo)
        {
       
                tipRep.Create(tipo);
                return RedirectToAction("Tipo");
         
        }

        public ActionResult Delete(int id)
        {
            tipRep.Delete(id);
            return RedirectToAction("Tipo");
        }

        public ActionResult UpdateTipo(int id)
        {


            var tipov = tipRep.getOnes(id);
            return View(tipov);
        }

        [HttpPost]
        public ActionResult UpdateTipo(Tipo tipo)
        {
            
         
            tipRep.Update(tipo);
            return RedirectToAction("Tipo");
        }


    }
}