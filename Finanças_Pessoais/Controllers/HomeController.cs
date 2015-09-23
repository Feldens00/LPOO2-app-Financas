using Finanças_Pessoais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finanças_Pessoais.Controllers
{
    public class HomeController : Controller
    {
        DespesasRepositorio desRep = new DespesasRepositorio();
        // GET: Home
        public ActionResult Index()
        {
            var desp = desRep.getLimit();
            return View(desp);
        }
    }
}