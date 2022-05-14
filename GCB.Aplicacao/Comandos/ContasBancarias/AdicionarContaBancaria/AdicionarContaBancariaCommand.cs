using GCB.Comum.Comandos;
using GCB.Comum.Extensoes;
using GCB.Dominio.Enums;
using GCB.Dominio.ObjetosValor;
using MediatR;
using Newtonsoft.Json;

namespace GCB.Aplicacao.Comandos.ContasBancarias.AdicionarContaBancaria
{
    public class AdicionarContaBancariaCommand : IRequest<CommandResult>
    {
        public string NomeBanco { get; private set; }
        public TipoConta TipoConta { get; private set; }
        public decimal SaldoAtual { get; private set; }

        public AdicionarContaBancariaCommand(string nomeBanco, string tipoConta, decimal? saldoAtual = 0)
        {
            NomeBanco = nomeBanco;
            TipoConta = tipoConta.ParseEnum<TipoConta>();
            SaldoAtual = saldoAtual ?? 0;
        }
    }
}
