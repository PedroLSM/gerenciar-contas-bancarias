using FluentValidation;
using GCB.Dominio.Enums;
using GCB.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.ContasBancarias.AdicionarContaBancaria
{
    public class AdicionarContaBancariaValidator : AbstractValidator<AdicionarContaBancariaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarContaBancariaValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(cb => cb.TipoConta)
                .IsInEnum().WithMessage("Mês inválido.")
                .NotEmpty().WithMessage("Tipo de conta requerido.");

            RuleFor(cb => cb.NomeBanco)
                .NotEmpty()
                .Length(2, 30)
                .WithMessage("Nome do banco está inválido.");

            RuleFor(cb => new { cb.NomeBanco, cb.TipoConta })
                .MustAsync((x, y) => DeveSerUnico(x.NomeBanco, x.TipoConta, y))
                .WithMessage("Já existem uma conta cadastrado com o mesmo nome e tipo de conta.");
        }
        public async Task<bool> DeveSerUnico(string nomeConta, TipoConta tipoConta, CancellationToken cancellationToken)
        {
            return !await _unitOfWork.ContaBancaria.ContaBancariaExiste(nomeConta, tipoConta);
        }
    }
}
