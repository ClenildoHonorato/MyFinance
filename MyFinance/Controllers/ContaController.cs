using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class ContaController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public ContaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            ContaModel contaModel = new ContaModel(HttpContextAccessor);
            ViewBag.ListaConta = contaModel.ListaConta();
            return View();
        }

        [HttpPost]
        public IActionResult CriarConta(ContaModel contaModel)
        {
            if (ModelState.IsValid)
            {
                string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
                contaModel.Insert(usuarioLogado);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CriarConta()
        {
            return View();
        }

        public IActionResult ExcluirConta(string id)
        {
            ContaModel contaModel = new ContaModel(HttpContextAccessor);
            contaModel.ExcluirConta(id);
            return RedirectToAction("Index");
        }
    }
}