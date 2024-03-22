using FluentValidation;

namespace GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimoPagamento
{
    public class AdicionarEmprestimoPagamentoValidator : AbstractValidator<AdicionarEmprestimoPagamentoCommand>
    {
        public AdicionarEmprestimoPagamentoValidator()
        {
            RuleFor(cb => cb.EmprestimoId)
                .NotEmpty().WithMessage("Empréstimo requerido.");
        }
    }
}
