using GCB.Comum.Comandos;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimoPagamento
{
    public class AdicionarEmprestimoPagamentoCommand : IRequest<CommandResult>
    {
        public Guid EmprestimoId { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public decimal ValorPago { get; private set; }

        public AdicionarEmprestimoPagamentoCommand(Guid emprestimoId, DateTime? dataPagamento, decimal valorPago)
        {
            EmprestimoId = emprestimoId;
            DataPagamento = dataPagamento ?? DateTime.Today;
            ValorPago = valorPago;
        }
    }
}
