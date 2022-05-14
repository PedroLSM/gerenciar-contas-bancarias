using Dapper;
using GCB.Comum.Factories;
using GCB.Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Referencias.ObterReferenciasAgrupadaPorAno
{
    public class ObterReferenciasAgrupadaPorAnoQueryHandler : IRequestHandler<ObterReferenciasAgrupadaPorAnoQuery, IEnumerable<ReferenciasAgrupadaPorAnoDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ObterReferenciasAgrupadaPorAnoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ReferenciasAgrupadaPorAnoDto>> Handle(ObterReferenciasAgrupadaPorAnoQuery request, CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.GetOpenConnection();
            
            var referencias = await ObterReferecias(connection);

            return referencias;
        }

        async Task<IEnumerable<ReferenciasAgrupadaPorAnoDto>> ObterReferecias(IDbConnection connection)
        {
            const string sqlReferencia = @"
                SELECT *
                FROM [Referencias]
                ORDER BY AnoReferencia DESC, Id Desc;
            ";

            var referencias = await connection.QueryAsync<ReferenciaDto>(sqlReferencia);

            return referencias
                .GroupBy(x => x.AnoReferencia)
                .Select(x => new ReferenciasAgrupadaPorAnoDto(x.Key, x.ToList()));
        }
    }
}
