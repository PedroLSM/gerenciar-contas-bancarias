using FluentValidation;
using GCB.Comum.Entidades;
using GCB.Dominio.Enums;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using MassTransit;
using System;

namespace GCB.Dominio.Entidades
{
    public class Referencia : Entity
    {
        public int Ano { get; private set; }
        public Mes Mes { get; private set; }

        public Real TotalRetirado { get; private set; }
        public Real TotalDepositado { get; private set; }
        public Real DiferencaSaldoAnterior { get; private set; }
        public Real Saldo { get; private set; }

        private Referencia() { }

        public Referencia(Mes mes)
        {
            Id = NewId.NextGuid();
            Ano = DateTime.Now.Year;
            Mes = mes;

            TotalRetirado ??= new Real(0);
            TotalDepositado ??= new Real(0);
            Saldo ??= new Real(0);
            DiferencaSaldoAnterior ??= new Real(0);

            Validate(this, new ReferenciaValidator());

            AddDomainEvent(new ReferenciaCriadaDomainEvent(Id));
            AddDomainEvent(new CalcularDiferencaSaldoDomainEvent());
        }

        public Referencia(Mes mes, Referencia ultimaReferencia) : this(mes)
        {
            if (ultimaReferencia is not null)
                Saldo =  new Real(ultimaReferencia.Saldo.Valor);
        }

        public Referencia(int ano, Mes mes, Referencia ultimaReferencia) : this(mes, ultimaReferencia)
        {
            Ano = ano;
        }

        public void CalcularDiferenciaSaldoAnterior(Referencia referenciaAnterior)
        {
            if (referenciaAnterior.Id == Id)
                DiferencaSaldoAnterior = new Real(Saldo.Valor);
            else
                DiferencaSaldoAnterior = Saldo - referenciaAnterior.Saldo;
        }

        public void AdicionarSaldo(Real saldoAtual)
        {
            if (saldoAtual.Positivo)
                AdicionarDeposito(saldoAtual);
            else
                AdicionarRetirada(saldoAtual * -1);
        }

        public void AdicionarDeposito(Real valor)
        {
            TotalDepositado += valor;
            Saldo += valor;
        }

        public void AdicionarRetirada(Real valor)
        {
            TotalRetirado += valor;
            Saldo -= valor;
        }
    }

    internal class ReferenciaValidator : AbstractValidator<Referencia>
    {
        public ReferenciaValidator()
        {
            RuleFor(rf => rf.Ano)
                .Equal(DateTime.Now.Year)
                .WithMessage("Ano de referência deve ser maior ou igual ao ano atual.");

            RuleFor(rf => rf.Mes)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Mês de referência inválido.");
        }
    }
}
