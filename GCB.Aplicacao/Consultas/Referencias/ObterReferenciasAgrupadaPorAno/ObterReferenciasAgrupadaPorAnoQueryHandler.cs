using Dapper;
using GCB.Comum.Factories;
using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using GCB.Dominio.ObjetosValor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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


            string sql = "SELECT Id, NomeBanco, TipoConta, Ativa, SaldoAtual FROM ContasBancarias";

            var result = await connection.QueryAsync<ContaTeste, decimal, ContaTeste>(
                sql,
                (conta, moeda) =>
                {
                    conta.SaldoAtual = new Real(moeda);
                    return conta;
                },
                splitOn: "SaldoAtual"
            );

            return referencias
                .GroupBy(x => x.AnoReferencia)
                .Select(x => new ReferenciasAgrupadaPorAnoDto(x.Key, x.ToList()));
        }
    }

    public class ContaTeste
    {
        public string NomeBanco { get; set; }
        public Real SaldoAtual { get; set; }
        public bool Ativa { get; set; }
    }
}
