using GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimo;
using GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimoPagamento;
using GCB.Aplicacao.Consultas.Emprestimos.ObterEmprestimos;
using GCB.Aplicacao.Consultas.Emprestimos.ObterPagamentosPorEmprestimo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GCB.Api.Controllers
{
    public class EmprestimoController : ApiController
    {
        [HttpGet("", Name = "ObterEmprestimos")]
        public async Task<IActionResult> ObterEmprestimos()
        {
            var response = await Mediator.Send(new ObterEmprestimosQuery());

            return Ok(response);
        }

        [HttpGet("ObterPagamentosPorEmprestimo")]
        public async Task<IActionResult> ObterPagamentosPorEmprestimo([FromQuery] ObterPagamentosPorEmprestimoQuery request)
        {
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarEmprestimo([FromBody] AdicionarEmprestimoCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }

        [HttpPost("AdicionarPagamento")]
        public async Task<IActionResult> AdicionarEmprestimoPagamento([FromBody] AdicionarEmprestimoPagamentoCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }
    }
}
