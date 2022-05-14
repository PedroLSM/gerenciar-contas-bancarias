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

namespace GCB.Aplicacao.Comandos.ContasBancarias.DesativarContaBancaria
{
    public class DesativarContaBancariaHandler : IRequestHandler<DesativarContaBancariaCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public DesativarContaBancariaHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(DesativarContaBancariaCommand request, CancellationToken cancellationToken)
        {
            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(request.ContaBancariaId);

            contaBancaria.DesativarConta();

            unitOfWork.ContaBancaria.Update(contaBancaria);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.OK, "Conta desativada", new { contaBancaria.Id });
        }
    }
}
