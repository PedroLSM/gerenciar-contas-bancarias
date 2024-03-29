﻿using FluentValidation;
using GCB.Comum.Entidades;
using GCB.Dominio.ObjetosValor;
using MassTransit;
using System;

namespace GCB.Dominio.Entidades
{
    public class DepositoBancario : Entity
    {
        public Guid ExtratoId { get; private set; }
        public string Descricao { get; private set; }
        public Real Valor { get; private set; }

        public DateTime DataRegistro { get; private set; }

        private DepositoBancario() { }

        public DepositoBancario(Guid extratoId, string descricao, Real valor)
        {
            Id = NewId.NextGuid();
            ExtratoId = extratoId;
            Descricao = descricao;
            Valor = valor;

            DataRegistro = DateTime.Now;

            Validate(this, new DepositoBancarioValidator());

            AddNotifications(Valor);
        }

        public DepositoBancario(Guid extratoId, string descricao, Real valor, DateTime dataRegistro)
        {
            Id = NewId.NextGuid();
            ExtratoId = extratoId;
            Descricao = descricao;
            Valor = valor;

            DataRegistro = dataRegistro;

            Validate(this, new DepositoBancarioValidator());

            AddNotifications(Valor);
        }
    }

    internal class DepositoBancarioValidator : AbstractValidator<DepositoBancario>
    {
        public DepositoBancarioValidator()
        {
            RuleFor(dp => dp.ExtratoId)
                .NotEmpty()
                .WithMessage("Necessário informar o extrato.");

            RuleFor(dp => dp.DataRegistro)
                .NotEmpty()
                .WithMessage("Necessário informar a data do deposito.");

            RuleFor(dp => dp.Valor.Valor)
                .GreaterThan(0)
                .WithMessage("Informe um valor maior que R$0.00");

            RuleFor(dp => dp.Descricao)
                .NotEmpty()
                .WithMessage("Necessário informar uma descrição.")
                .MinimumLength(5)
                .WithMessage("Descrição deve conter no minimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("Descrição deve conter no máximo 100 caracteres");
        }
    }
}
