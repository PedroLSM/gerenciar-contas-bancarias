using GCB.Comum.Comandos;
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

namespace GCB.Aplicacao.Comandos.ContasBancarias.AtivarContaBancaria
{
    public class AtivarContaBancariaHandler : IRequestHandler<AtivarContaBancariaCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public AtivarContaBancariaHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(AtivarContaBancariaCommand request, CancellationToken cancellationToken)
        {
            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(request.ContaBancariaId);

            contaBancaria.ReativarConta(new Real(request.SaldoAtual));

            unitOfWork.ContaBancaria.Update(contaBancaria);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.OK, "Conta reativada", new { contaBancaria.Id });
        }
    }
}
