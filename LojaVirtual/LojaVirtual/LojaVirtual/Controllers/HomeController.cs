using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
                bool isValid = Validator.TryValidateObject(contato, context, listMessage,true);

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
                        sb.Append(texto.ErrorMessage);
                    }
                    ViewData["MSG_E"] = sb.ToString();
                }

            }
            catch (Exception e)
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
