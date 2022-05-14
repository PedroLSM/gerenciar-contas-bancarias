using FluentValidation;

namespace GCB.Aplicacao.Comandos.Extratos.RealizarRetiradaBancaria
{
    public class RealizarRetiradaBancariaValidator : AbstractValidator<RealizarRetiradaBancariaCommand>
    {
        public RealizarRetiradaBancariaValidator()
        {
            RuleFor(dp => dp.ExtratoId)
                .NotEmpty()
                .WithMessage("Necessário informar o extrato.");


            RuleFor(dp => dp.Valor)
                .GreaterThan(0)
                .WithMessage("Informe um valor maior que R$0.00");

            RuleFor(dp => dp.Descricao)
                .NotEmpty()
                .WithMessage("Necessário informar uma descrição.")
                .MinimumLength(5)
                .WithMessage("Descrição deve conter no minimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("Descrição deve conter no máximo 100 caracteres");
        }
    }
}
