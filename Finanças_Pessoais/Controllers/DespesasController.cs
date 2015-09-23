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
            ViewBag.ListTipo = Tipo.tipo;
            return View();
        }

        [HttpPost]
        public ActionResult CreateDespesas(Despesas despesas)
        {
            Tipo.popular();
            despRep.Create(despesas);
            return RedirectToAction("Despesas");
        }

        public ActionResult Delete(int Id)
        {
            despRep.Delete(Id);
            return RedirectToAction("Despesas");
        }

        public ActionResult Update(int Id)
        {
            var despesas = despRep.getOne(Id);
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