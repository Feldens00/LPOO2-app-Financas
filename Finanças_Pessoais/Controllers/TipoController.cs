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
            //Tipo.popular();
            tipRep.Create(tipo);
            return RedirectToAction("Tipo");
        }

        public ActionResult Delete(int id)
        {
            tipRep.Delete(id);
            return RedirectToAction("Tipo");
        }

        public ActionResult Update(int id)
        {
            // Tipo.popular();
           
            var tipo = tipRep.getOne(id);
            return View(tipo);
        }

        [HttpPost]
        public ActionResult Update(Tipo tipo)
        {
            //Tipo.popular();
         
            tipRep.Update(tipo);
            return RedirectToAction("Tipo");
        }


    }
}