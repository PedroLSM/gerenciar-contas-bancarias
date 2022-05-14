using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterExtratosPorReferencia
{
    public class ExtratosPorReferenciaQuery : IRequest<IEnumerable<ExtratoPorReferenciaDto>>
    {
        public Guid ReferenciaId { get; private set; }

        public ExtratosPorReferenciaQuery(Guid referenciaId)
        {
            ReferenciaId = referenciaId;
        }
    }
}
