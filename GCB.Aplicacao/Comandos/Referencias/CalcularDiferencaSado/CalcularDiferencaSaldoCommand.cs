using GCB.Comum.Comandos;
using GCB.Comum.Extensoes;
using GCB.Dominio.Enums;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.Referencias.CalcularDiferencaSado
{
    public class CalcularDiferencaSaldoCommand : IRequest<CommandResult>
    {
        public Guid ReferenciaAtual { get; private set; }
        public Guid ReferenciaAnterior { get; private set; }

        public CalcularDiferencaSaldoCommand(Guid referenciaAtual, Guid referenciaAnterior)
        {
            ReferenciaAtual = referenciaAtual;
            ReferenciaAnterior = referenciaAnterior;
        }
    }
}
