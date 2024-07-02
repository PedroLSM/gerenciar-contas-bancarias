using GCB.Comum.Comandos;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.Referencias.ExcluirReferencia
{
    public class ExcluirReferenciaCommand : IRequest<CommandResult>
    {
        public Guid ReferenciaId { get; private set; }

        public ExcluirReferenciaCommand(Guid referenciaId)
        {
            ReferenciaId = referenciaId;
        }
    }
}
