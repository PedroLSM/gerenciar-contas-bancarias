using GCB.Comum.Comandos;
using GCB.Dominio.DTOs;
using GCB.Dominio.Entidades;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using GCB.Dominio.Servicos;
using MediatR;
using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Extratos.CarregarExtratoCSV
{
    public class CarregarExtratoCSVHandler : IRequestHandler<CarregarExtratoCSVCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICSVServico csvServico;

        public CarregarExtratoCSVHandler(
            IUnitOfWork unitOfWork,
            ICSVServico csvServico
        )
        {
            this.unitOfWork = unitOfWork;
            this.csvServico = csvServico;
        }

        public async Task<CommandResult> Handle(CarregarExtratoCSVCommand request, CancellationToken cancellationToken)
        {
            var extrato = unitOfWork.Extrato.GetSingle(request.ExtratoId);

            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(extrato.ContaBancariaId);

            var csvExtrato = csvServico.LerCSV<CsvExtratoDTO>(request.Arquivo);

            extrato.AdicionarExtrato(csvExtrato, contaBancaria);

            unitOfWork.Extrato.Update(extrato);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Extrato carregado.", new
            {
                ExtratoId = extrato.Id,
                Saldo = extrato.Saldo.Valor,
                TotalDepositado = extrato.TotalDepositado.Valor,
                TotalRetirado = extrato.TotalRetirado.Valor,
                Csv = csvExtrato
            });
        }
    }
}
