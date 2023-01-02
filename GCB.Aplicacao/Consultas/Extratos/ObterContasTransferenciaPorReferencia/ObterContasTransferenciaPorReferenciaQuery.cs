using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterContasTransferenciaPorReferencia
{
    public class ObterContasTransferenciaPorReferenciaQuery : IRequest<IEnumerable<ObterContasTransferenciaPorReferenciaDto>>
    {
        public Guid ReferenciaId { get; private set; }
        public Guid ExtratoId { get; private set; }

        public ObterContasTransferenciaPorReferenciaQuery(Guid referenciaId, Guid extratoId)
        {
            ReferenciaId = referenciaId;
            ExtratoId = extratoId;
        }
    }
}
