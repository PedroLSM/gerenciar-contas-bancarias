using FluentValidation;
using GCB.Comum.Entidades;
using GCB.Dominio.DTOs;
using GCB.Dominio.Enums;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using MassTransit;
using System;
using System.Collections.Generic;

namespace GCB.Dominio.Entidades
{
    public class ContaBancaria : Entity
    {
        public string NomeBanco { get; private set; }
        public TipoConta TipoConta { get; private set; }
        public Real SaldoAtual { get; private set; }
        public bool Ativa { get; private set; }

        public ContaBancaria(string nomeBanco, TipoConta tipoConta, Real saldoAtual = null)
        {
            Id = NewId.NextGuid();
            NomeBanco = nomeBanco;
            TipoConta = tipoConta;
            SaldoAtual = saldoAtual ?? new Real(0);

            Ativa = true;

            Validate(this, new ContaBancariaValidator());
            
            AddNotifications(SaldoAtual);

            AddDomainEvent(new ContaBancariaCriadaDomainEvent(Id, SaldoAtual));
        }

        private ContaBancaria() { }

        public void AdicionarDeposito(Real real)
        {
            SaldoAtual += real;
        }

        public void AdicionarRetirada(Real real)
        {
            SaldoAtual -= real;
        }

        public void DesativarConta()
        {
            if (!Ativa)
                AddNotification("Desativar Conta", "Esta conta bancária já esta desativada.");

            Ativa = false;
        }

        public void ReativarConta(Real novoSaldo)
        {
            if (Ativa)
                AddNotification("Reativar Conta", "Esta conta bancária já esta ativada.");

            Ativa = true;
            
            var diferenciaComSaldoAnterior = novoSaldo - SaldoAtual;
            
            if (diferenciaComSaldoAnterior.Positivo)
                AdicionarDeposito(diferenciaComSaldoAnterior);
            else
                AdicionarRetirada(diferenciaComSaldoAnterior * -1);

            AddDomainEvent(new ContaBancariaReativadaDomainEvent(Id, diferenciaComSaldoAnterior));
        }
    }

    internal class ContaBancariaValidator : AbstractValidator<ContaBancaria>
    {
        public ContaBancariaValidator()
        {
            RuleFor(cb => cb.NomeBanco)
                .NotEmpty()
                .Length(2, 30)
                .WithMessage("Nome do banco está inválido.");

            RuleFor(cb => cb.TipoConta)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Tipo de conta está inválido.");
        }
    }
}
