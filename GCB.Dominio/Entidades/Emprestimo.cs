using FluentValidation;
using GCB.Comum.Entidades;
using GCB.Dominio.ObjetosValor;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCB.Dominio.Entidades
{
    public class Emprestimo : Entity
    {
        public string Devedor { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public Real ValorEmprestimo { get; private set; }
        public Real ValorPrevisto { get; private set; }
        public Real ValorPago { get; private set; }
        public Real ValorDevendo => ValorPrevisto - ValorPago;

        private readonly IList<EmprestimoPagamento> _pagamentos;
        public IReadOnlyList<EmprestimoPagamento> Pagamentos => _pagamentos.ToArray();

        private Emprestimo() {
            _pagamentos ??= new List<EmprestimoPagamento>();
        }

        public Emprestimo(string devedor, DateTime? dataEmprestimo, Real valorEmprestimo, Real valorPrevisto)
            : this()
        {
            Id = NewId.NextGuid();

            Devedor = devedor;
            DataEmprestimo = dataEmprestimo ?? DateTime.Today;
            ValorEmprestimo = valorEmprestimo;
            ValorPrevisto = valorPrevisto ?? valorEmprestimo;
            ValorPago = new Real(0);

            Validate(this, new EmprestimoValidator());

            AddNotifications(ValorEmprestimo);
            AddNotifications(ValorPrevisto);
        }

        public void AdicionarPagamento(DateTime? dataPagamento, Real valorPago)
        {
            var pagamento = new EmprestimoPagamento(Id, dataPagamento, valorPago);

            AddNotifications(pagamento);

            _pagamentos.Add(pagamento);

            ValorPago += valorPago;
        }
    }

    internal class EmprestimoValidator : AbstractValidator<Emprestimo>
    {
        public EmprestimoValidator()
        {
            RuleFor(ex => ex.Devedor)
                .NotEmpty()
                .WithMessage("Nome do devedor é necessária.");

            RuleFor(ex => ex.DataEmprestimo)
                .NotEmpty()
                .WithMessage("Data do empréstimo é necessária.");

            RuleFor(ex => ex.ValorEmprestimo.Valor)
                .GreaterThan(0)
                .WithMessage("Valor do empréstimo não pode ser menor ou igual a zero.");

            RuleFor(ex => ex.ValorPrevisto.Valor)
                .GreaterThan(0)
                .WithMessage("Valor previsto não pode ser menor ou igual a zero.")
                .GreaterThanOrEqualTo(ex => ex.ValorEmprestimo.Valor)
                .WithMessage("Valor previsto não pode ser menor que o valor do empréstimo.");
        }
    }

}
