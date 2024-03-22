using GCB.Comum.Comandos;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimoPagamento
{
    public class AdicionarEmprestimoPagamentoHandler : IRequestHandler<AdicionarEmprestimoPagamentoCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public AdicionarEmprestimoPagamentoHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(AdicionarEmprestimoPagamentoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = unitOfWork.Emprestimo.GetSingle(request.EmprestimoId);

            emprestimo.AdicionarPagamento(request.DataPagamento, new Real(request.ValorPago));

            unitOfWork.Emprestimo.Update(emprestimo);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Pagamento adicionado", new { 
                emprestimo.Id, 
                ValorPago = emprestimo.ValorPago.Valor, 
                ValorDevendo = emprestimo.ValorDevendo.Valor
            });
        }
    }
}
