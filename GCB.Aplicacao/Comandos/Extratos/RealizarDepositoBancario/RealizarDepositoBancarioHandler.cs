using GCB.Comum.Comandos;
using GCB.Dominio.Entidades;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Extratos.RealizarDepositoBancario
{
    public class RealizarDepositoBancarioHandler : IRequestHandler<RealizarDepositoBancarioCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public RealizarDepositoBancarioHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(RealizarDepositoBancarioCommand request, CancellationToken cancellationToken)
        {
            var extrato = unitOfWork.Extrato.GetSingle(request.ExtratoId);
            
            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(extrato.ContaBancariaId);

            var depositoBancario = new DepositoBancario(request.ExtratoId, request.Descricao, new Real(request.Valor));

            extrato.AdicionarDeposito(depositoBancario, contaBancaria);

            unitOfWork.Extrato.Update(extrato);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Deposito adicionado", new { depositoBancario.Id });
        }
    }
}
