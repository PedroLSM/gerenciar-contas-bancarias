using GCB.Comum.Comandos;
using MediatR;
using System;

namespace GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimo
{
    public class AdicionarEmprestimoCommand : IRequest<CommandResult>
    {
        public string Devedor { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public decimal ValorEmprestimo { get; private set; }
        public decimal ValorPrevisto { get; private set; }

        public AdicionarEmprestimoCommand(string devedor, DateTime? dataEmprestimo, decimal valorEmprestimo, decimal? valorPrevisto)
        {
            Devedor = devedor;
            DataEmprestimo = dataEmprestimo ?? DateTime.Today;
            ValorEmprestimo = valorEmprestimo;
            ValorPrevisto = valorPrevisto ?? valorEmprestimo;
        }
    }
}
