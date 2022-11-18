using GCB.Comum.Comandos;
using GCB.Dominio.Entidades;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Extratos.RealizarRetiradaBancaria
{
    public class RealizarRetiradaBancariaHandler : IRequestHandler<RealizarRetiradaBancariaCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public RealizarRetiradaBancariaHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(RealizarRetiradaBancariaCommand request, CancellationToken cancellationToken)
        {
            var extrato = unitOfWork.Extrato.GetSingle(request.ExtratoId);
            
            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(extrato.ContaBancariaId);

            var retiradaBancaria = new RetiradaBancaria(request.ExtratoId, request.Descricao, new Real(request.Valor));

            extrato.AdicionarRetirada(retiradaBancaria, contaBancaria);
            
            unitOfWork.Extrato.Update(extrato);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Retirada realizada", new { extrato.Saldo, extrato.TotalDepositado, extrato.TotalRetirado });
        }
    }
}
