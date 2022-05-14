using GCB.Comum.Comandos;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.ContasBancarias.DesativarContaBancaria
{
    public class DesativarContaBancariaCommand : IRequest<CommandResult>
    {
        public Guid ContaBancariaId { get; private set; }

        public DesativarContaBancariaCommand(Guid contaBancariaId)
        {
            ContaBancariaId = contaBancariaId;
        }
    }
}
