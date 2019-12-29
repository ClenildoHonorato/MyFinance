namespace MyFinance.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyFinance.Models;

    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? id)
        {
            if(id != null && id == 0)
            {
                HttpContext.Session.SetString("IdUsaruiLogado",string.Empty);
                HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
            }

            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
            bool login = usuario.ValidarLogin();
            if (login)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.RegistrarUsurio();
                return RedirectToAction("Sucesso");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}