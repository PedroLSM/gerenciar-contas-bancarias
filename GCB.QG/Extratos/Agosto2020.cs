using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace GCB.QG.Extratos
{
    public static class Agosto2020
    {
        private static readonly Retirada[] Retiradas = new Retirada[]
            {
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA CARTÃO BRADESCO", 2274.70m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA LUZ", 78.00m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA LUZ - CASA", 129.50m ),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA AGUA", 45.60m   ),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA INTERNET", 80.00m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA TIM", 65.00m ),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA PAG", 80.00m ),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CLICK CONTA", 6.80m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA INTERNET II", 55.00m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA INTERNET III", 73.80m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "SAQUE - ANDERSON", 350.00m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA PAG II", 686.60m),
                new Retirada("9E450000-67A0-641C-26E6-08D8C53080D1", "PAG. CONTA INTERNET III", 19.00m),
                new Retirada("9E450000-67A0-641C-1B35-08D8C530925A","PAG. CONTA CARTÃO NUBANK", 600.00m),
                new Retirada("9E450000-67A0-641C-1B35-08D8C530925A","PAG. CONTA CARTÃO NUBANK II", 100.00m),
                new Retirada("9E450000-67A0-641C-1B35-08D8C530925A","TRANSFERENCIA ANDREIA", 1000.00m),
                new Retirada("9E450000-67A0-641C-1B35-08D8C530925A","PAG. CONTA CARTÃO NUBANK III",  22.00m),
                new Retirada("9E450000-67A0-641C-0C79-08D8C530973C","PAG. CONTA CARTÃO DIGIO",  100.00m),
            };

        private static readonly Deposito[] Depositos = new Deposito[]
        {
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 1200),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 960 ),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 100 ),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 500 ),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 1300),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 272.5m),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 2.75m ),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 700  ),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 650  ),
                new Deposito("9E450000-67A0-641C-26E6-08D8C53080D1", "DEPOSITO CONTA BRADESCO", 1618 ),
                new Deposito("9E450000-67A0-641C-1B35-08D8C530925A", "DEPOSITO CONTA NUBANK", 1000),
                new Deposito("9E450000-67A0-641C-1B35-08D8C530925A", "DEPOSITO CONTA NUBANK", 300),
                new Deposito("9E450000-67A0-641C-1B35-08D8C530925A", "DEPOSITO CONTA NUBANK", 600),
                new Deposito("9E450000-67A0-641C-1B35-08D8C530925A", "DEPOSITO CONTA NUBANK", 600),
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
