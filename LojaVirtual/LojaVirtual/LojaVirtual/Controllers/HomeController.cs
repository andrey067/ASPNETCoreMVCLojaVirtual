using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.DataBase;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private LojaVirtualContext _banco;
        public HomeController(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] NewsletterEmail newsletter)
        {
            //Validadacoes
            if (ModelState.IsValid)
            {
                //adicao no bando de dados
                _banco.NewsletterEmail.Add(newsletter);
                _banco.SaveChanges();
                TempData["MSG_S"] = "E-mail cadastrado, agora você vai receber  promocoes especias no seu e-mail";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato();
                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                var listMessage = new List<ValidationResult>();
                var context = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, context, listMessage, true);

                //Identificacao dos erros nos campos
                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);


                    ViewData["MSG_S"] = "Mensagem de contato enviada com sucesso";
                }

                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in listMessage)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }

            }
            catch (Exception )
            {
                ViewData["MSG_E"] = "Opss tivemos um problema no envio tente novamente";
                //TODO - Implementar LOG
            }
            return View("Contato");


        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
