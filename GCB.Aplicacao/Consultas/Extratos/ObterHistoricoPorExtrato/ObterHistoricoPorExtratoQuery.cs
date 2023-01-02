using MediatR;
using System;
using System.Collections.Generic;

namespace GCB.Aplicacao.Consultas.Extratos.ObterHistoricoPorExtrato
{
    public class ObterHistoricoPorExtratoQuery : IRequest<IEnumerable<ObterHistoricoPorExtratoDto>>
    {
        public Guid ExtratoId { get; private set; }

        public ObterHistoricoPorExtratoQuery(Guid extratoId)
        {
            ExtratoId = extratoId;
        }
    }
}
