using FluentValidation;
using GCB.Dominio.Enums;
using GCB.Dominio.Repositorios;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia
{
    public class AdicionarReferenciaValidator : AbstractValidator<AdicionarReferenciaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarReferenciaValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(r => r.MesReferencia)
                .IsInEnum().WithMessage("Mês inválido.")
                .NotEmpty().WithMessage("Mês de referência requerido.")
                .MustAsync(DeveSerUnico).WithMessage("Mês de referência já está cadastrado.");

        }

        public async Task<bool> DeveSerUnico(Mes mes, CancellationToken cancellationToken)
        {
            return !await _unitOfWork.Referencia.ReferenciaExiste(mes);
        }
    }
}
