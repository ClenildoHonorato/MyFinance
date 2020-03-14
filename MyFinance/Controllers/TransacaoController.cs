namespace MyFinance.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyFinance.Models;
    using System;
    using System.Collections.Generic;

    public class TransacaoController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;
        public TransacaoController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            TransacaoModel transacaoModel = new TransacaoModel(HttpContextAccessor);
            ViewBag.ListaTransacao = transacaoModel.ListaTransacao();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(TransacaoModel transacaoModel)
        {
            if (ModelState.IsValid)
            {
                string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
                transacaoModel.InsertUpdate(usuarioLogado);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Registrar(int? id)
        {
            if (id != null)
            {
                string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
                TransacaoModel transacaoModel = new TransacaoModel(HttpContextAccessor);
                ViewBag.Registro = transacaoModel.CarregarRegistro(id, usuarioLogado);
            }

            ViewBag.ListaPlanoConta = new PlanoContaModel(HttpContextAccessor).ListaPLanoConta();
            ViewBag.ListaConta = new ContaModel(HttpContextAccessor).ListaConta();
 
            return View();
        }

        public IActionResult ExcluirTransacao(int id)
        {
            string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
            TransacaoModel transacaoModel = new TransacaoModel(HttpContextAccessor);
            ViewBag.Registro = transacaoModel.CarregarRegistro(id, usuarioLogado);

            return View();
        }

        public IActionResult Excluir(string id)
        {
            TransacaoModel transacaoModel = new TransacaoModel(HttpContextAccessor);
            transacaoModel.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Extrato(TransacaoModel transacaoModel)
        {
            transacaoModel.HttpContextAccessor = HttpContextAccessor;
            ViewBag.ListaTransacao = transacaoModel.ListaTransacao();
            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            return View();
        }

        public IActionResult Dashboard()
        {
            string usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsaruiLogado");
            List<Dashboard> lista = new Dashboard().RetornarGraficoPie(usuarioLogado);
            string valores = "";
            string labels = "";
            string cores = "";
            var random = new Random();

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].Total.ToString() + ",";
                labels += "'" + lista[i].PlanoConta.ToString() + "',";
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Cores = cores;
            ViewBag.Labels = labels;
            ViewBag.Valores = valores;
            return View();
        }
    }
}