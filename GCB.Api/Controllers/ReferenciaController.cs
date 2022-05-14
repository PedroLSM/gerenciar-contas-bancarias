using GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia;
using GCB.Aplicacao.Consultas.Referencias.ObterReferenciasAgrupadaPorAno;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
