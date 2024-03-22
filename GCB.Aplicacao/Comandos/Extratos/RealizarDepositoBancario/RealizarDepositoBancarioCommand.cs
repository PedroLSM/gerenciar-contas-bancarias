using GCB.Comum.Comandos;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.Extratos.RealizarDepositoBancario
{
    public class RealizarDepositoBancarioCommand : IRequest<CommandResult>
    {
        public Guid ExtratoId { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime? Data { get; private set; }

        public RealizarDepositoBancarioCommand(Guid extratoId, string descricao, decimal valor, DateTime? data = null)
        {
            ExtratoId = extratoId;
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }
    }
}
