using GCB.Comum.Comandos;
using GCB.Dominio.Repositorios;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Referencias.ExcluirReferencia
{
    public class ExcluirReferenciaHandler 
        : IRequestHandler<ExcluirReferenciaCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public ExcluirReferenciaHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(ExcluirReferenciaCommand request, CancellationToken cancellationToken)
        {
            var referencia = unitOfWork.Referencia.GetSingle(request.ReferenciaId);

            unitOfWork.Referencia.Delete(referencia);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Referência removida", new { Id = request.ReferenciaId });
        }
    }
}
