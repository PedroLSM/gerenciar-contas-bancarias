using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace GCB.QG.Extratos
{
    public static class Novembro2020
    {
        private static readonly Retirada[] Retiradas = new Retirada[]
        {
            /*
                9E450000-67A0-641C-A672-08D8C53B08E2  - BRADESCO
                9E450000-67A0-641C-C7D2-08D8C53B08E2  - NUBANK
                9E450000-67A0-641C-E60A-08D8C53B08E2  - DIGIO	
             */
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO INTERNET", 79.90m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "CONTA DE LUZ", 146m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO DIGIO", 400.33m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "CONTA DE AGUA", 13m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO INTERNET II", 35m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO CONTA ANDREIA", 2466.69m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO ANDRE NUBANK", 623.79m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO CLAUDIA PAG", 1108m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "TRANSFERENCIA MEU NUBANK", 2000m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "TRANSFERENCIA MEU DIGIO",1000m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO INTERNET III", 120m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "PAGAMENTO RENNER", 112m),
            new Retirada("9E450000-67A0-641C-A672-08D8C53B08E2", "TRANSFERENCIA", 550m),
            new Retirada("9E450000-67A0-641C-C7D2-08D8C53B08E2", "PAGAMENTO NUBANK I", 680m),
            new Retirada("9E450000-67A0-641C-C7D2-08D8C53B08E2", "PAGAMENTO NUBANK II", 172m),
            new Retirada("9E450000-67A0-641C-C7D2-08D8C53B08E2", "TRANSFERENCIA ANDERSON", 240m),
        };

        private static readonly Deposito[] Depositos = new Deposito[]
        {
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 1600),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 600),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 500),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 200),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 2000),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 900),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 840),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 300),
                new Deposito("9E450000-67A0-641C-A672-08D8C53B08E2", "DEPOSITO CONTA BRADESCO", 950),
                new Deposito("9E450000-67A0-641C-C7D2-08D8C53B08E2", "DEPOSITO CONTA NUBANK", 2000),
                new Deposito("9E450000-67A0-641C-E60A-08D8C53B08E2", "DEPOSITO CONTA DIGIO", 1000),
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
