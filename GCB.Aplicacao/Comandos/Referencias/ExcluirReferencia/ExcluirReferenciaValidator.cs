using FluentValidation;
using GCB.Dominio.Repositorios;
using System;

namespace GCB.Aplicacao.Comandos.Referencias.ExcluirReferencia
{
    public class ExcluirReferenciaValidator : AbstractValidator<ExcluirReferenciaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExcluirReferenciaValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(r => r.ReferenciaId)
                .NotEmpty().WithMessage("Identificador da referência é requerido.")
                .Must(DeveExistir).WithMessage("Referência não foi encontrada.");
        }

        public bool DeveExistir(Guid referenciaId)
        {
            return _unitOfWork.Referencia.GetSingleOrDefault(referenciaId) != null;
        }
    }
}
