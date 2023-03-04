using FluentValidation;

namespace GCB.Aplicacao.Comandos.Extratos.CarregarExtratoCSV
{
    public class CarregarExtratoCSVValidator : AbstractValidator<CarregarExtratoCSVCommand>
    {
        public CarregarExtratoCSVValidator()
        {
            RuleFor(dp => dp.ExtratoId)
                .NotEmpty()
                .WithMessage("Necessário informar o extrato.");

            RuleFor(dp => dp.Arquivo)
                .NotEmpty()
                .WithMessage("Necessário anexar o arquivo.");
        }
    }
}
