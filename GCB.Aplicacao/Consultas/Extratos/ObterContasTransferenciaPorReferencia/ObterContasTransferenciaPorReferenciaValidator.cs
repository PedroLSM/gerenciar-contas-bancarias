using FluentValidation;
using GCB.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterContasTransferenciaPorReferencia
{
    public class ObterContasTransferenciaPorReferenciaValidator : AbstractValidator<ObterContasTransferenciaPorReferenciaQuery>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObterContasTransferenciaPorReferenciaValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(r => r.ReferenciaId)
                .NotEmpty().WithMessage("Referência requerida.")
                .Must(Existe).WithMessage("Referência informada não existe.");

            RuleFor(r => r.ExtratoId)
                .NotEmpty().WithMessage("Extrato requerido.")
                .Must(ExisteExtrato).WithMessage("Extrato informado não existe.");

        }

        public bool Existe(Guid referenciaId)
        {
            return _unitOfWork.Referencia.GetSingleOrDefault(referenciaId) is not null;
        }

        public bool ExisteExtrato(Guid extratoId)
        {
            return _unitOfWork.Extrato.GetSingleOrDefault(extratoId) is not null;
        }
    }
}
