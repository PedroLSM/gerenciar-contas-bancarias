using GCB.Comum.Comandos;
using GCB.Comum.Extensoes;
using GCB.Dominio.Enums;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.Extratos.RealizarRetiradaBancaria
{
    public class RealizarRetiradaBancariaCommand : IRequest<CommandResult>
    {
        public Guid ExtratoId { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public Guid? ExtratoTransferenciaId { get; private set; }
        public TipoRetirada TipoRetirada { get; private set; }

        public RealizarRetiradaBancariaCommand(Guid extratoId, string descricao, decimal valor, string tipoRetirada, Guid? extratoTransferenciaId)
        {
            ExtratoId = extratoId;
            Descricao = descricao;
            Valor = valor;
            TipoRetirada = tipoRetirada.ParseEnum<TipoRetirada>();
            ExtratoTransferenciaId = extratoTransferenciaId;
        }
    }
}
