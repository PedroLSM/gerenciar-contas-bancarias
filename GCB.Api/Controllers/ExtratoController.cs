using GCB.Aplicacao.Comandos.Extratos.CarregarExtratoCSV;
using GCB.Aplicacao.Comandos.Extratos.RealizarDepositoBancario;
using GCB.Aplicacao.Comandos.Extratos.RealizarRetiradaBancaria;
using GCB.Aplicacao.Consultas.Extratos.ObterContasTransferenciaPorReferencia;
using GCB.Aplicacao.Consultas.Extratos.ObterExtratosPorReferencia;
using GCB.Aplicacao.Consultas.Extratos.ObterHistoricoPorExtrato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GCB.Api.Controllers
{
    public class ExtratoController : ApiController
    {

        [HttpGet("")]
        public async Task<IActionResult> ObterExtratosDeUmaReferencia([FromQuery] Guid referenciaId)
        {
            var response = await Mediator.Send(new ExtratosPorReferenciaQuery(referenciaId));

            return Ok(response);
        }

        [HttpGet("ContasTransferencia")]
        public async Task<IActionResult> ObterContasTransferenciaPorReferencia([FromQuery] Guid referenciaId, [FromQuery] Guid extratoId)
        {
            var response = await Mediator.Send(new ObterContasTransferenciaPorReferenciaQuery(referenciaId, extratoId));

            return Ok(response);
        }

        [HttpGet("Historico")]
        public async Task<IActionResult> ObterHistoricoDeUmExtrato([FromQuery] Guid extratoId)
        {
            var response = await Mediator.Send(new ObterHistoricoPorExtratoQuery(extratoId));

            return Ok(response);
        }

        [HttpPost("Adicionar/DepositoBancario")]
        public async Task<IActionResult> AdicionarDeposito([FromBody] RealizarDepositoBancarioCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }

        [HttpPost("Adicionar/RetiradaBancaria")]
        public async Task<IActionResult> AdicionarRetirada([FromBody] RealizarRetiradaBancariaCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }

        [HttpPost("Adicionar/Extrato")]
        public async Task<IActionResult> AdicionarExtrato([FromForm] CarregarExtratoCSVCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }
    }
}
