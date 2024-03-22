using FluentValidation;
using GCB.Dominio.Repositorios;

namespace GCB.Aplicacao.Comandos.Emprestimos.AdicionarEmprestimo
{
    public class AdicionarEmprestimoValidator : AbstractValidator<AdicionarEmprestimoCommand>
    {
        public AdicionarEmprestimoValidator()
        {
            RuleFor(cb => cb.Devedor)
                .NotEmpty().WithMessage("Devedor requerido.");
        }
    }
}
