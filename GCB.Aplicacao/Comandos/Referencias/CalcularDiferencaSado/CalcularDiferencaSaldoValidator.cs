using FluentValidation;
using GCB.Dominio.Repositorios;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Referencias.CalcularDiferencaSado
{
    public class CalcularDiferencaSaldoValidator : AbstractValidator<CalcularDiferencaSaldoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalcularDiferencaSaldoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(r => r.ReferenciaAtual)
                .NotEmpty().WithMessage("Guid da referência atual requerido.")
                .MustAsync(DeveExistir).WithMessage("Referência atual não está cadastrada.");

            RuleFor(r => r.ReferenciaAnterior)
                .NotEmpty().WithMessage("Guid da referência anterior requerido.")
                .MustAsync(DeveExistir).WithMessage("Referência anterior não está cadastrada.");

        }

        public Task<bool> DeveExistir(Guid referenciaId, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitOfWork.Referencia.GetSingleOrDefault(referenciaId) is not null);
        }
    }
}
