using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using GCB.Dominio.ObjetosValor;
using Xunit;

namespace GCB.Testes.Entidades
{
    public class ContaBancariaTestes
    {
        #pragma warning disable xUnit1012 // Null should not be used for value type parameters
        [Theory]
        [InlineData("", null)]
        [InlineData("b", null)]
        [InlineData("b", TipoConta.Corrente)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", null)]
        [InlineData("BB", null)]
        #pragma warning restore xUnit1012 // Null should not be used for value type parameters
        public void Nao_pode_criar_conta_bancaria_com_nome_vazio_tamanho_menor_2_ou_maior_30_ou_com_tipo_vazio(string conta, TipoConta tipoConta)
        {
            var contaBancaria = new ContaBancaria(conta, tipoConta);

            Assert.True(contaBancaria.Invalid);
        }

        [Theory]
        [InlineData("BB", TipoConta.Corrente)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", TipoConta.Corrente)]
        public void Pode_criar_conta_bancaria_com_nome_de_tamanho_maior_1_e_menor_31_sem_saldo(string conta, TipoConta tipoConta)
        {
            var contaBancaria = new ContaBancaria(conta, tipoConta);

            Assert.True(contaBancaria.Valid);
            Assert.Equal(0, contaBancaria.SaldoAtual.Valor);
        }

        [Fact]
        public void Pode_criar_conta_bancaria_com_saldo()
        {
            var dinheiro = new Real(10);
            var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca, dinheiro);

            Assert.True(contaBancaria.Valid);
            Assert.Equal(dinheiro, contaBancaria.SaldoAtual);
        }

        [Fact]
        public void Ao_reativar_conta_bancaria_o_saldo_deve_atualizar_para_o_atual()
        {
            var dinheiro = new Real(200);
            var contaBancaria = new ContaBancaria("BB", TipoConta.Poupanca, dinheiro);

            contaBancaria.DesativarConta();

            var atual = new Real(100);
            contaBancaria.ReativarConta(atual);

            Assert.True(contaBancaria.Valid);
            Assert.Equal(atual, contaBancaria.SaldoAtual);
        }
    }
}
