using GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia;
using GCB.Aplicacao.Comandos.Referencias.CalcularDiferencaSado;
using GCB.Aplicacao.Comandos.Referencias.ExcluirReferencia;
using GCB.Aplicacao.Consultas.Referencias.ObterReferenciasAgrupadaPorAno;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GCB.Api.Controllers
{
    public class ReferenciaController : ApiController
    {
        [HttpGet("", Name = "ObterReferenciasAgrupadaPorAno")]

        public async Task<IActionResult> ObterReferencias()
        {
            var response = await Mediator.Send(new ObterReferenciasAgrupadaPorAnoQuery());

            return Ok(response);
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarReferencia([FromBody] AdicionarReferenciaCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }

        [HttpPost("CalcularDiferencaSaldo")]
        public async Task<IActionResult> CalcularDiferencaSaldoReferencia([FromBody] CalcularDiferencaSaldoCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }

        [HttpPost("ExcluirReferencia")]
        public async Task<IActionResult> ExcluirReferencia([FromBody] ExcluirReferenciaCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }
    }
}
