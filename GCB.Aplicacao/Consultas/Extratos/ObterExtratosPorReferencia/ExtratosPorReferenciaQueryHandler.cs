using Dapper;
using GCB.Comum.Factories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterExtratosPorReferencia
{
    public class ExtratosPorReferenciaQueryHandler : IRequestHandler<ExtratosPorReferenciaQuery, IEnumerable<ExtratoPorReferenciaDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ExtratosPorReferenciaQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ExtratoPorReferenciaDto>> Handle(ExtratosPorReferenciaQuery request, CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.GetOpenConnection();

            var extratos = await ObterExtratos(connection, request.ReferenciaId);

            return extratos;
        }

        async Task<IEnumerable<ExtratoPorReferenciaDto>> ObterExtratos(IDbConnection connection, Guid referenciaId)
        {
            const string sqlReferencia = @"
                SELECT Extratos.Id as ExtratoId	
	                  , ContaBancariaId	
	                  , ReferenciaId	
	                  , NomeBanco	
	                  , Saldo	
	                  , TotalDepositado	
	                  , TotalRetirado
	                  , Ativa
                FROM Extratos
	                JOIN ContasBancarias ON ContasBancarias.Id = Extratos.ContaBancariaId
                WHERE ReferenciaId = @ReferenciaId;
            ";

            return await connection.QueryAsync<ExtratoPorReferenciaDto>(sqlReferencia, new { ReferenciaId = referenciaId });
        }
    }
}
