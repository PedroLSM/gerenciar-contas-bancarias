using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace GCB.QG.Extratos
{
    public static class Janeiro2021
    {
        private static readonly Retirada[] Retiradas = new Retirada[]
        {
             /*
                9E450000-67A0-641C-09EA-08D8C592934E   - BRADESCO
                9E450000-67A0-641C-2C15-08D8C592935B   - NUBANK
                9E450000-67A0-641C-42C4-08D8C592935B   - DIGIO
                9E450000-67A0-641C-C4E3-08D8C5936B35   - ITAU
                9E450000-67A0-641C-7733-08D8C5938E1F   - INTER
             */

            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "TRANFERENCIA PARA NUBANK", 2000m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO INTERNET + AGUA + LUZ", 288.04m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO DIGIO + NUBANK", 891.08m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO CLARO + SANTANDER", 64.63m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO INTERNET + LUZ", 187.56m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO SAFRA + LUZ", 400.02m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "TRANSFERENCIA PAYPAL", 200m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "TRANFERECIA CAIXA + LUZ", 500m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO LUZ", 203m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO SAFRA II", 100m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "TRANSFERENCIA JOAO MORAIS", 460m),
            //new Retirada("9E450000-67A0-641C-09EA-08D8C592934E", "PAGAMENTO AGUA + INTERNET + PAG! + TRANSFERENCIA", 583.54m),
            //new Retirada("9E450000-67A0-641C-2C15-08D8C592935B", "PAGAMENTO NUBANK", 1164.82m),
            //new Retirada("9E450000-67A0-641C-2C15-08D8C592935B", "TRANFERENCIA PARA ANDERSON", 400m),
            //new Retirada("9E450000-67A0-641C-42C4-08D8C592935B", "PAGAMENTO DIGIO", 437.44m),
            //new Retirada("9E450000-67A0-641C-C4E3-08D8C5936B35", "PAGAMENTO INTERNET", 65m),
        };

        private static readonly Deposito[] Depositos = new Deposito[]
        {
                //new Deposito("9E450000-67A0-641C-09EA-08D8C592934E", "DEPOSITO CONTA BRADESCO", 1662.86m),
                //new Deposito("9E450000-67A0-641C-09EA-08D8C592934E", "DEPOSITO CONTA BRADESCO", 1300),
                //new Deposito("9E450000-67A0-641C-09EA-08D8C592934E", "DEPOSITO CONTA BRADESCO", 220),
                //new Deposito("9E450000-67A0-641C-09EA-08D8C592934E", "DEPOSITO CONTA BRADESCO", 800),
                //new Deposito("9E450000-67A0-641C-09EA-08D8C592934E", "DEPOSITO CONTA BRADESCO", 1400),
                //new Deposito("9E450000-67A0-641C-09EA-08D8C592934E", "DEPOSITO CONTA BRADESCO", 120),
                new Deposito("9E450000-67A0-641C-09EA-08D8C592934E", "DEPOSITO CONTA BRADESCO", 60),
                //new Deposito("9E450000-67A0-641C-2C15-08D8C592935B", "DEPOSITO CONTA NUBANK", 2000),
        };

        public static async System.Threading.Tasks.Task AdicionarExtratoAsync(HttpClient httpClient)
        {
            foreach (var dep in Retiradas)
            {
                var response = await httpClient.PostAsJsonAsync("/GCB/Extrato/Adicionar/RetiradaBancaria", dep);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            foreach (var dep in Depositos)
            {
                var response = await httpClient.PostAsJsonAsync("/GCB/Extrato/Adicionar/DepositoBancario", dep);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
