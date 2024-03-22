using Dapper;
using GCB.Comum.Factories;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Emprestimos.ObterEmprestimos
{
    public class ObterEmprestimosQueryHandler : IRequestHandler<ObterEmprestimosQuery, IEnumerable<ObterEmprestimosDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ObterEmprestimosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ObterEmprestimosDto>> Handle(ObterEmprestimosQuery request, CancellationToken cancellationToken)
        {
            using var connection = sqlConnectionFactory.GetOpenConnection();

            var emprestimos = await ObterEmprestimos(connection);

            return emprestimos;
        }

        async Task<IEnumerable<ObterEmprestimosDto>> ObterEmprestimos(IDbConnection connection)
        {
            const string sqlReferencia = @"
                SELECT  Id
                      , Devedor	
	                  , DataEmprestimo	
	                  , ValorEmprestimo	
	                  , ValorPrevisto
	                  , ValorPago
                FROM Emprestimos;
            ";

            var emprestimos = await connection.QueryAsync<ObterEmprestimosDto>(sqlReferencia);

            return emprestimos.OrderByDescending(x => x.ValorDevendo);
        }
    }
}
