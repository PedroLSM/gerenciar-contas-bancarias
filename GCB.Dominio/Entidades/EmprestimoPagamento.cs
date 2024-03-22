using FluentValidation;
using GCB.Comum.Entidades;
using GCB.Dominio.ObjetosValor;
using MassTransit;
using System;

namespace GCB.Dominio.Entidades
{
    public class EmprestimoPagamento : Entity
    {
        public Guid EmprestimoId { get; private set; }

        public DateTime DataPagamento { get; private set; }
        public Real ValorPago { get; private set; }

        private EmprestimoPagamento() { }

        public EmprestimoPagamento(Guid emprestimoId, DateTime? dataPagamento, Real valorPago)
        {
            Id = NewId.NextGuid();

            EmprestimoId = emprestimoId;
            DataPagamento = dataPagamento ?? DateTime.Today;
            ValorPago = valorPago;
        }
    }

    internal class EmprestimoPagamentoValidator : AbstractValidator<EmprestimoPagamento>
    {
        public EmprestimoPagamentoValidator()
        {
            RuleFor(ex => ex.EmprestimoId)
                .NotEmpty()
                .WithMessage("Emprestimo é necessário.");
        }
    }
}
