using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {

        /*Todo controlador herda da classe Controller
         * 
         * E sempre vai retornar ActionResult ou IActionResult
         * 
         */
        public ActionResult Visualizar()
        {
            Produto produto = GetProduto();
            return View(produto);
        }

        private Produto GetProduto()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Xbox One S",
                Descricao = "4k Run",
                Valor = 2000
            };
        }
    }
}
