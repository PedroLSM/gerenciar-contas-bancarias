using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Referencias.ObterReferenciasAgrupadaPorAno
{
    public class ObterReferenciasAgrupadaPorAnoQuery : IRequest<IEnumerable<ReferenciasAgrupadaPorAnoDto>>
    {
    }
}
