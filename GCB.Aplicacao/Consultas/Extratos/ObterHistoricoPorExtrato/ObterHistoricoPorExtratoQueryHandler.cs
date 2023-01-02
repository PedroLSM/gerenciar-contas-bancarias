using Dapper;
using GCB.Comum.Factories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterHistoricoPorExtrato
{
    public class ObterHistoricoPorExtratoQueryHandler : IRequestHandler<ObterHistoricoPorExtratoQuery, IEnumerable<ObterHistoricoPorExtratoDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ObterHistoricoPorExtratoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ObterHistoricoPorExtratoDto>> Handle(ObterHistoricoPorExtratoQuery request, CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.GetOpenConnection();

            var historico = await ObterHistorico(connection, request.ExtratoId);

            return historico;
        }

        async Task<IEnumerable<ObterHistoricoPorExtratoDto>> ObterHistorico(IDbConnection connection, Guid extratoId)
        {
            const string sqlReferencia = @"
                SELECT Id as OperacaoId, ExtratoId, Descricao, ValorDepositado as Valor, DataRegistro, 'Deposito' as TipoOperacao
                FROM DepositosBancarios WHERE ExtratoId = @ExtratoId

                UNION

                SELECT Id as OperacaoId, ExtratoId, Descricao, ValorRetirado as Valor, DataRegistro, 'Retirada' as TipoOperacao
                FROM RetiradasBancarias WHERE ExtratoId = @ExtratoId

                UNION

                SELECT newid() as OperacaoId, Id as ExtratoId, 'Saldo Atual' as Descricao, Saldo as Valor, getdate() as DataRegistro, 'Saldo' as TipoOperacao
                FROM Extratos WHERE Id = @ExtratoId

                ORDER BY DataRegistro DESC
            ";

            return await connection.QueryAsync<ObterHistoricoPorExtratoDto>(sqlReferencia, new { ExtratoId = extratoId });
        }
    }
}
