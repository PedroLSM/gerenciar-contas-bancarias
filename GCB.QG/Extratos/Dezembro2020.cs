using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace GCB.QG.Extratos
{
    public static class Dezembro2020
    {
        private static readonly Retirada[] Retiradas = new Retirada[]
        {
            /*
                9E450000-67A0-641C-2DF0-08D8C53CC79A  - BRADESCO
                9E450000-67A0-641C-4421-08D8C53CC79A  - NUBANK
                9E450000-67A0-641C-54B8-08D8C53CC79A  - DIGIO
             */

            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO AGUA + LUZ + CLARO", 105.46m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "TRANSFERENCIA CLAUDIA", 100m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO CONTA ANDREA", 1286.30m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO AGUA + LUZ + INTERNET", 292.16m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO AGUA + LUZ + INTERNET", 218.50m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO NUBANK + CORPVS + DIGIO", 639.25m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO LUZ", 173.30m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO FORTBRASIL", 189m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "TRNASFERENCIA CLAUDIA", 400m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO CREDIAMIGO", 208m),
            new Retirada("9E450000-67A0-641C-2DF0-08D8C53CC79A", "PAGAMENTO PAG! + INTERNET", 1002.12m),
            new Retirada("9E450000-67A0-641C-4421-08D8C53CC79A", "PAGAMENTO NUBANK", 903.88m),
            new Retirada("9E450000-67A0-641C-4421-08D8C53CC79A", "TRANSFERENCIA  NUBANK", 300m),
            new Retirada("9E450000-67A0-641C-54B8-08D8C53CC79A", "PAGAMENTO DIGIO", 249.88m),
        };

        private static readonly Deposito[] Depositos = new Deposito[]
        {
                new Deposito("9E450000-67A0-641C-2DF0-08D8C53CC79A", "DEPOSITO CONTA BRADESCO", 1698),
                new Deposito("9E450000-67A0-641C-2DF0-08D8C53CC79A", "DEPOSITO CONTA BRADESCO", 1300),
                new Deposito("9E450000-67A0-641C-2DF0-08D8C53CC79A", "DEPOSITO CONTA BRADESCO", 1000),
                new Deposito("9E450000-67A0-641C-2DF0-08D8C53CC79A", "DEPOSITO CONTA BRADESCO", 500),
                new Deposito("9E450000-67A0-641C-2DF0-08D8C53CC79A", "DEPOSITO CONTA BRADESCO", 750),
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
