using GCB.Aplicacao.Comandos.Extratos.RealizarDepositoBancario;
using GCB.Aplicacao.Comandos.Extratos.RealizarRetiradaBancaria;
using GCB.Aplicacao.Consultas.Extratos.ObterExtratosPorReferencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
