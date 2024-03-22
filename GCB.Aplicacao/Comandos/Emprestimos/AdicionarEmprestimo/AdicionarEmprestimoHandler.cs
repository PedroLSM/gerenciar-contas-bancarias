using GCB.Comum.Comandos;
using GCB.Dominio.Entidades;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimo
{
    public class AdicionarEmprestimoHandler : IRequestHandler<AdicionarEmprestimoCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public AdicionarEmprestimoHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(AdicionarEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = new Emprestimo(request.Devedor, request.DataEmprestimo, new Real(request.ValorEmprestimo), new Real(request.ValorPrevisto));

            unitOfWork.Emprestimo.Add(emprestimo);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Empréstimo adicionada", new { emprestimo.Id });
        }
    }
}
