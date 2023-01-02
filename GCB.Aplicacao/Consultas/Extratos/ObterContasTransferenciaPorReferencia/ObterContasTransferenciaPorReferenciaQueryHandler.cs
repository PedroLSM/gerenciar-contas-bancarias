using Dapper;
using GCB.Comum.Factories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterContasTransferenciaPorReferencia
{
    public class ObterContasTransferenciaPorReferenciaQueryHandler : IRequestHandler<ObterContasTransferenciaPorReferenciaQuery, IEnumerable<ObterContasTransferenciaPorReferenciaDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ObterContasTransferenciaPorReferenciaQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ObterContasTransferenciaPorReferenciaDto>> Handle(ObterContasTransferenciaPorReferenciaQuery request, CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.GetOpenConnection();

            var extratos = await ObterExtratos(connection, request.ReferenciaId, request.ExtratoId);

            return extratos;
        }

        async Task<IEnumerable<ObterContasTransferenciaPorReferenciaDto>> ObterExtratos(
            IDbConnection connection, Guid referenciaId, Guid extratoId
        )
        {
            const string sqlReferencia = @"
                SELECT Extratos.Id as ExtratoId	
	                  , ContaBancariaId	
	                  , ReferenciaId	
	                  , NomeBanco
                FROM Extratos
	                JOIN ContasBancarias ON ContasBancarias.Id = Extratos.ContaBancariaId
                WHERE ReferenciaId = @ReferenciaId AND Extratos.Id <> @ExtratoId;
            ";

            return await connection.QueryAsync<ObterContasTransferenciaPorReferenciaDto>(sqlReferencia, new { ReferenciaId = referenciaId, ExtratoId = extratoId });
        }
    }
}
