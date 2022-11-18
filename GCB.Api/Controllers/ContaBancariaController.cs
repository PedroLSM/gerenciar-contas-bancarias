using GCB.Aplicacao.Comandos.ContasBancarias.AdicionarContaBancaria;
using GCB.Aplicacao.Comandos.ContasBancarias.AtivarContaBancaria;
using GCB.Aplicacao.Comandos.ContasBancarias.DesativarContaBancaria;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GCB.Api.Controllers
{
    public class ContaBancariaController : ApiController
    {
        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarContaBancaria([FromBody] AdicionarContaBancariaCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }

        [HttpPost("Ativar")]
        public async Task<IActionResult> AtivarContaBancaria([FromBody] AtivarContaBancariaCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }

        [HttpPost("Desativar")]
        public async Task<IActionResult> DesativarContaBancaria([FromBody] DesativarContaBancariaCommand request)
        {
            var response = await Mediator.Send(request);

            return response.ActionResult();
        }
    }
}
