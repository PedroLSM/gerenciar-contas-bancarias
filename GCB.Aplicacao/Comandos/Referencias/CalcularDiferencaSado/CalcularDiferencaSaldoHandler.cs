using GCB.Comum.Comandos;
using GCB.Dominio.Repositorios;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Referencias.CalcularDiferencaSado
{
    public class CalcularDiferencaSaldoHandler 
        : IRequestHandler<CalcularDiferencaSaldoCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public CalcularDiferencaSaldoHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(CalcularDiferencaSaldoCommand request, CancellationToken cancellationToken)
        {
            var referenciaAtual = unitOfWork.Referencia.GetSingle(request.ReferenciaAtual);
            var referenciaAnterior = unitOfWork.Referencia.GetSingle(request.ReferenciaAnterior);

            referenciaAtual.CalcularDiferenciaSaldoAnterior(referenciaAnterior);

            unitOfWork.Referencia.Update(referenciaAnterior);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.OK, "Diferença com o saldo da refêrencia anterior calculada.", new { Atual = referenciaAtual.Id, Anterior = referenciaAnterior.Id });
        }
    }
}
