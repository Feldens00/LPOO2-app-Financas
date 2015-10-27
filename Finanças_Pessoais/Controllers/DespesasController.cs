using Entity;
using FinancasConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorys;

namespace Finanças_Pessoais.Controllers
{
    public class DespesasController : Controller
    {
        DataBase database = new DataBase();
        DespesasRepositorio despRep = new DespesasRepositorio();
        TipoRepositorio tipRep = new TipoRepositorio();

        // GET: Aluno
        public ActionResult Despesas()
        {
            var despesas = despRep.getAll();    

            return View(despesas);
        }
        [HttpGet]
        public ActionResult CreateDespesas()
        {

            List<Tipo> ListTipo = new List<Tipo>(tipRep.getAll());
            ViewBag.ListTipo = ListTipo;
            return View();
        }

        [HttpPost]
        public ActionResult CreateDespesas(Despesas despesas)
        {
            List<Tipo> ListTipo = new List<Tipo>(tipRep.getAll());
            ViewBag.ListTipo = ListTipo;
            if (ModelState.IsValid) {
                despRep.Create(despesas);
                return RedirectToAction("Despesas");
            }
            return View();
            
        }

        public ActionResult Delete(int id)
        {
            despRep.Delete(id);
            return RedirectToAction("Despesas");
        }

        public ActionResult Update(int id)
        {
            List<Tipo> ListTipo = new List<Tipo>(tipRep.getAll());
            ViewBag.ListTipo = ListTipo;
            var despesas = despRep.getOne(id);
            return View(despesas);
        }

        [HttpPost]
        public ActionResult Update(Despesas despesas)
        {
           
            despRep.Update(despesas);
            return RedirectToAction("Despesas");
        }
    }
}