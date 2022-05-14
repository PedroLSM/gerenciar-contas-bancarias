using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Dominio.ObjetosValor
{
    public class Real : ValueObject
    {
        public string Sigla { get; private set; }
        public string Simbolo { get; private set; }
        public decimal Valor { get; private set; }
        public bool Positivo => Valor >= 0;
        public bool Negativo => Valor < 0;

        public Real(decimal valor)
        {
            Sigla = "BRL";
            Simbolo = "R$";
            Valor = valor;

            Validate(this, new RealValidator());
        }

        public static Real operator +(Real b, Real c)
        {
            Real real = new Real(b.Valor + c.Valor);

            return real;
        }

        public static Real operator -(Real b, Real c)
        {
            Real real = new Real(b.Valor - c.Valor);

            return real;
        }
        public static Real operator *(Real b, decimal c)
        {
            Real real = new Real(b.Valor * c);

            return real;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Sigla;
            yield return Simbolo;
            yield return Valor;
        }
    }

    internal class RealValidator : AbstractValidator<Real>
    {
        public RealValidator()
        {
            RuleFor(din => din.Sigla)
                .NotEmpty()
                .Length(1, 10)
                .WithMessage("Sigla deve conter de 1 a 10 caracteres.");

            RuleFor(din => din.Simbolo)
                .NotEmpty()
                .Length(1, 10)
                .WithMessage("Simbolo deve conter de 1 a 10 caracteres.");

        }
    }
}
