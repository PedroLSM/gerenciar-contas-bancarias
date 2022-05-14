using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.ContasBancarias.AtivarContaBancaria
{
    public class AtivarContaBancariaValidator : AbstractValidator<AtivarContaBancariaCommand>
    {
        public AtivarContaBancariaValidator()
        {
            RuleFor(cb => cb.ContaBancariaId)
                .NotEmpty()
                .WithMessage("Necessário informar a conta bancaria.");
        }
    }
}
