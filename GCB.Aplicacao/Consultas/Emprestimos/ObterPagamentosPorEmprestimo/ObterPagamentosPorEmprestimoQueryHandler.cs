using Dapper;
using GCB.Comum.Factories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Emprestimos.ObterPagamentosPorEmprestimo
{
    public class ObterPagamentosPorEmprestimoQueryHandler : IRequestHandler<ObterPagamentosPorEmprestimoQuery, IEnumerable<ObterPagamentosPorEmprestimoDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ObterPagamentosPorEmprestimoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ObterPagamentosPorEmprestimoDto>> Handle(ObterPagamentosPorEmprestimoQuery request, CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.GetOpenConnection();

            var pagamentos = await ObterPagamentosPorEmprestimo(connection, request.EmprestimoId);

            return pagamentos;
        }

        async Task<IEnumerable<ObterPagamentosPorEmprestimoDto>> ObterPagamentosPorEmprestimo(IDbConnection connection, Guid emprestimoId)
        {
            const string sqlReferencia = @"
                SELECT  Id
                      , EmprestimoId
	                  , DataPagamento
	                  , ValorPago
                FROM EmprestimoPagamentos
                WHERE EmprestimoId = @EmprestimoId
                ORDER BY DataPagamento DESC;
            ";

            return await connection.QueryAsync<ObterPagamentosPorEmprestimoDto>(sqlReferencia, new { EmprestimoId = emprestimoId });

        }
    }
}
