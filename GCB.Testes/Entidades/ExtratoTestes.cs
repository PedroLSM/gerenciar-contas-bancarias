using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using GCB.Dominio.EventosDominio;
using GCB.Dominio.ObjetosValor;
using MassTransit;
using System.Linq;
using Xunit;

namespace GCB.Testes.Entidades
{
    public class ExtratoTestes
    {
        [Fact]
        public void Ao_ser_realizado_um_deposito_deve_ser_adicionando_o_total_deposital_atual_e_incrementar_saldo_e_diferenca()
        {
            var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca);

            var referenciaId = NewId.NextGuid();

            var extrato = new Extrato(contaBancaria.Id, referenciaId);

            var deposito = new DepositoBancario(extrato.Id, "Teste", new Real(10));
            
            extrato.AdicionarDeposito(deposito, contaBancaria);

            Assert.Equal(10, extrato.Saldo.Valor);
            Assert.Equal(10, extrato.TotalDepositado.Valor);
        }

        [Fact]
        public void Ao_ser_realizado_uma_retirada_deve_ser_diminuido_o_total_deposito_atual_e_diminuir_saldo_e_diferenca()
        {
            var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca);

            var referenciaId = NewId.NextGuid();

            var extrato = new Extrato(contaBancaria.Id, referenciaId);

            var retirada = new RetiradaBancaria(extrato.Id, "Teste", new Real(10));

            extrato.AdicionarRetirada(retirada, contaBancaria);

            Assert.Equal(-10, extrato.Saldo.Valor);
            Assert.Equal(10, extrato.TotalRetirado.Valor);
        }

        [Fact]
        public void Nao_pode_ser_registrado_um_deposito_em_uma_conta_desativada()
        {
            var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca);

            contaBancaria.DesativarConta();

            var referenciaId = NewId.NextGuid();

            var extrato = new Extrato(contaBancaria.Id, referenciaId);

            var deposito = new DepositoBancario(extrato.Id, "Teste", new Real(10));

            extrato.AdicionarDeposito(deposito, contaBancaria);

            Assert.True(extrato.Invalid);
        }

        [Fact]
        public void Nao_pode_ser_registrado_uma_retirada_em_uma_conta_desativada()
        {
            var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca);

            contaBancaria.DesativarConta();

            var referenciaId = NewId.NextGuid();

            var extrato = new Extrato(contaBancaria.Id, referenciaId);

            var retirada = new RetiradaBancaria(extrato.Id, "Teste", new Real(10));

            extrato.AdicionarRetirada(retirada, contaBancaria);

            Assert.True(extrato.Invalid);
        }

        //[Fact]
        //public void Ao_criar_um_extrato_deve_ser_adicionado_o_evento_de_extrato_criado()
        //{
        //    var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca);

        //    var referenciaId = NewId.NextGuid();

        //    var extrato = new Extrato(contaBancaria.Id, referenciaId);

        //    Assert.Contains(extrato.DomainEvents, de => de.GetType().Name == nameof(ExtratoCriadoDomainEvent));
        //}

        [Fact]
        public void Ao_realizar_um_deposito_ou_uma_retirada_deve_ser_criado_o_evento_de_deposito_ou_retirada()
        {
            var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca);

            var referenciaId = NewId.NextGuid();

            var extrato = new Extrato(contaBancaria.Id, referenciaId);

            var deposito = new DepositoBancario(extrato.Id, "Teste", new Real(10));
            var retirada = new RetiradaBancaria(extrato.Id, "Teste", new Real(10));

            extrato.AdicionarDeposito(deposito, contaBancaria);
            extrato.AdicionarRetirada(retirada, contaBancaria);

            Assert.Contains(extrato.DomainEvents, de => de.GetType().Name == nameof(DepositoBancarioRealizadoDomainEvent));
            Assert.Contains(extrato.DomainEvents, de => de.GetType().Name == nameof(RetiradaBancariaRealizadaDomainEvent));
        }
    }
}
