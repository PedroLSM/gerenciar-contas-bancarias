using GCB.Comum.Comandos;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.ContasBancarias.AtivarContaBancaria
{
    public class AtivarContaBancariaCommand : IRequest<CommandResult>
    {
        public Guid ContaBancariaId { get; private set; }
        public decimal SaldoAtual { get; private set; }

        public AtivarContaBancariaCommand(Guid contaBancariaId, decimal saldoAtual)
        {
            ContaBancariaId = contaBancariaId;
            SaldoAtual = saldoAtual;
        }
    }
}
