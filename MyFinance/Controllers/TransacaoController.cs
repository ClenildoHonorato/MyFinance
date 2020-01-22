namespace MyFinance.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyFinance.Models;

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
            ViewBag.ListaTransacao = new TransacaoModel(HttpContextAccessor).ListaTransacao();

            return View();
        }

        public IActionResult Extrato()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}