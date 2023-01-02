using FluentValidation;
using GCB.Dominio.Repositorios;
using System;

namespace GCB.Aplicacao.Consultas.Extratos.ObterHistoricoPorExtrato
{
    public class ObterHistoricoPorExtratoValidator : AbstractValidator<ObterHistoricoPorExtratoQuery>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObterHistoricoPorExtratoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(r => r.ExtratoId)
                .NotEmpty().WithMessage("Extrato requerido.")
                .Must(Existe).WithMessage("Extrato informado não existe.");

        }

        public bool Existe(Guid extratoId)
        {
            return _unitOfWork.Extrato.GetSingleOrDefault(extratoId) is not null;
        }
    }
}
