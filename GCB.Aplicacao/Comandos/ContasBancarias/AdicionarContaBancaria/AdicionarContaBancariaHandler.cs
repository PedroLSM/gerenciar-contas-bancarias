using GCB.Comum.Comandos;
using GCB.Dominio.Entidades;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.ContasBancarias.AdicionarContaBancaria
{
    public class AdicionarContaBancariaHandler : IRequestHandler<AdicionarContaBancariaCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public AdicionarContaBancariaHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(AdicionarContaBancariaCommand request, CancellationToken cancellationToken)
        {
            var contaBancaria = new ContaBancaria(request.NomeBanco, request.TipoConta, new Real(request.SaldoAtual));

            unitOfWork.ContaBancaria.Add(contaBancaria);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Conta bancaria adicionada", new { contaBancaria.Id });
        }
    }
}
