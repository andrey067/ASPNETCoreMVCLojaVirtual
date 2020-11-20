using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Models;
using LojaVirtual.Models.Constantes;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index(int? pagina)
        {
            IPagedList<Cliente> clientes = _clienteRepository.ObterTodosClientes(pagina);

            return View(clientes);
        }

        [ValideteHttpReferer]
        public IActionResult AtivarOuDesativar(int id)
        {
            Cliente cliente = _clienteRepository.ObterCliente(id);
            cliente.Situacao = (cliente.Situacao == SituacaoConstante.Ativo  ? cliente.Situacao = SituacaoConstante.Desativado : cliente.Situacao = SituacaoConstante.Ativo);
            _clienteRepository.Atualizar(cliente);
            TempData["MSG_S"] = Mensagem.MSG_S001;
            return RedirectToAction(nameof(Index));

        }
    }
}
