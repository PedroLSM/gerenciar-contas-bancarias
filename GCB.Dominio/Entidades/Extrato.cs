using Azure.Core;
using FluentValidation;
using GCB.Comum.Entidades;
using GCB.Dominio.DTOs;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCB.Dominio.Entidades
{
    public class Extrato : Entity
    {
        public Guid ContaBancariaId { get; private set; }
        public Guid ReferenciaId { get; private set; }
        public Real Saldo { get; private set; }
        public Real TotalDepositado { get; private set; }
        public Real TotalRetirado { get; private set; }

        private readonly IList<RetiradaBancaria> _retiradas;
        public IReadOnlyList<RetiradaBancaria> RetiradasBancarias => _retiradas.ToArray();

        private readonly IList<DepositoBancario> _depositos;
        public IReadOnlyList<DepositoBancario> DepositosBancarios => _depositos.ToArray();

        private Extrato()
        {
            _retiradas ??= new List<RetiradaBancaria>();
            _depositos ??= new List<DepositoBancario>();
        }

        public Extrato(Guid contaBancariaId, Guid referenciaId) : this()
        {
            Id = NewId.NextGuid();
            ContaBancariaId = contaBancariaId;
            ReferenciaId = referenciaId;

            Saldo ??= new Real(0);
            TotalDepositado ??= new Real(0);
            TotalRetirado ??= new Real(0);

            Validate(this, new ExtratoValidator());
        }

        public Extrato(Guid contaBancariaId, Guid referenciaId, Real saldo) : this(contaBancariaId, referenciaId)
        {
            Saldo = saldo;

            AddNotifications(Saldo);
        }

        public void AdicionarDeposito(DepositoBancario deposito, ContaBancaria conta)
        {
            AddNotifications(deposito);

            if (!conta.Ativa)
                AddNotification("Ativa", "Não é possivel adicionar um deposito em uma conta desativada.");

            _depositos.Add(deposito);

            TotalDepositado += deposito.Valor;
            Saldo += deposito.Valor;

            AddDomainEvent(new DepositoBancarioRealizadoDomainEvent(deposito.Id, ReferenciaId, ContaBancariaId, deposito.Valor));
        }

        public void AdicionarRetirada(RetiradaBancaria retirada, ContaBancaria conta)
        {
            AddNotifications(retirada);

            if (!conta.Ativa)
                AddNotification("Ativa", "Não é possivel adicionar uma retirada em uma conta desativada.");

            _retiradas.Add(retirada);

            TotalRetirado += retirada.Valor;
            Saldo -= retirada.Valor;

            AddDomainEvent(new RetiradaBancariaRealizadaDomainEvent(retirada.Id, ReferenciaId, ContaBancariaId, retirada.Valor));
        }

        public void AdicionarExtrato(IEnumerable<CsvExtratoDTO> csvExtrato, ContaBancaria contaBancaria)
        {
            foreach (var extrato in csvExtrato)
            {
                if (extrato.ValorFormatado >= 0)
                {
                    var depositoBancario = new DepositoBancario(
                        Id,
                        extrato.Descricao,
                        new Real(Math.Abs(extrato.ValorFormatado)),
                        extrato.DataFormatada
                    );

                    AdicionarDeposito(depositoBancario, contaBancaria);
                }
                else
                {
                    var retiradaBancario = new RetiradaBancaria(
                        Id, 
                        extrato.Descricao, 
                        new Real(Math.Abs(extrato.ValorFormatado)), 
                        extrato.DataFormatada
                    );

                    AdicionarRetirada(retiradaBancario, contaBancaria);
                }
            }
        }
    }
    internal class ExtratoValidator : AbstractValidator<Extrato>
    {
        public ExtratoValidator()
        {
            RuleFor(ex => ex.ContaBancariaId)
                .NotEmpty()
                .WithMessage("Conta bancaria é necessária.");
        }
    }
}
