using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class PlanoContaController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public PlanoContaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            PlanoContaModel planoContaModel   = new PlanoContaModel(HttpContextAccessor);
            ViewBag.ListaPlanoConta = planoContaModel.ListaPLanoConta();
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel planoContaModel)
        {
            if (ModelState.IsValid)
            {
                string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
                planoContaModel.InsertUpdate(usuarioLogado);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta(int? id)
        {
            if (id != null)
            {
                PlanoContaModel planoContaModel = new PlanoContaModel(HttpContextAccessor);
                ViewBag.Registro = planoContaModel.CarregarRegistro(id);
            }
            return View();
        }

        public IActionResult ExcluirPlanoConta(string id)
        {
            PlanoContaModel planoContaModel = new PlanoContaModel(HttpContextAccessor);
            planoContaModel.ExcluirConta(id);
            return RedirectToAction("Index");
        }
    }
}