using FluentValidation;
using GCB.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterExtratosPorReferencia
{
    public class ExtratoPorReferenciaValidator : AbstractValidator<ExtratosPorReferenciaQuery>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExtratoPorReferenciaValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(r => r.ReferenciaId)
                .NotEmpty().WithMessage("Referência requerida.")
                .Must(Existe).WithMessage("Referência informada não existe.");

        }

        public bool Existe(Guid referenciaId)
        {
            return !(_unitOfWork.Referencia.GetSingleOrDefault(referenciaId) is null);
        }
    }
}
