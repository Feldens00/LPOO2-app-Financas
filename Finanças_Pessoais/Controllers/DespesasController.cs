using Finanças_Pessoais.Models;
using FinancasConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            Tipo.popular();

            ViewBag.ListTipo = tipRep.getAll(); ;
            return View();
        }

        [HttpPost]
        public ActionResult CreateDespesas(Despesas despesas)
        {
            Tipo.popular();
            despRep.Create(despesas);
            return RedirectToAction("Despesas");
        }

        public ActionResult Delete(int id)
        {
            despRep.Delete(id);
            return RedirectToAction("Despesas");
        }

        public ActionResult Update(int id)
        {
            Tipo.popular();
            ViewBag.ListTipo = tipRep.getAll(); ;
            var despesas = despRep.getOne(id);
            return View(despesas);
        }

        [HttpPost]
        public ActionResult Update(Despesas despesas)
        {
            Tipo.popular();
            ViewBag.ListTipo = tipRep.getAll(); ;
            despRep.Update(despesas);
            return RedirectToAction("Despesas");
        }
    }
}