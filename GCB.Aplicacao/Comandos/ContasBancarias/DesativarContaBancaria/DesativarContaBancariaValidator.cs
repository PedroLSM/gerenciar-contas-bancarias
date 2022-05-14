using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.ContasBancarias.DesativarContaBancaria
{
    public class DesativarContaBancariaValidator : AbstractValidator<DesativarContaBancariaCommand>
    {
        public DesativarContaBancariaValidator()
        {
            RuleFor(cb => cb.ContaBancariaId)
                .NotEmpty()
                .WithMessage("Necessário informar a conta bancaria.");
        }
    }
}
