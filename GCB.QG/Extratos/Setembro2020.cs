using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace GCB.QG.Extratos
{
    public static class Setembro2020
    {
        private static readonly Retirada[] Retiradas = new Retirada[]
        {
            /*
                9E450000-67A0-641C-844F-08D8C530FE5A - BRADESCO
                9E450000-67A0-641C-9D22-08D8C530FE5A - NUBANK
                9E450000-67A0-641C-AA77-08D8C530FE5A - DIGIO			
             */
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "TRANSFERENCIA JOAO MORAIS ALVES", 570m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG.CONTA CARTÃO BRADESCO", 2348.39m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG.AGUA", 52m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG.LUZ", 138.37m   ),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG. LUZ II", 176.52m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG.NUBANK ANDRE", 706.29m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG.INTERNET", 79.90m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG. ANDREIA", 1547.53m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG. FORTBRASIL", 112.23m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG. DIGIO ANDRE",246.96m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "PAG.INTERNET II", 73.70m),
            new Retirada("9E450000-67A0-641C-844F-08D8C530FE5A", "SAPICON INTERNET", 55m),
            new Retirada("9E450000-67A0-641C-9D22-08D8C530FE5A", "PAG. NUBANK", 800.00m),
            new Retirada("9E450000-67A0-641C-9D22-08D8C530FE5A", "TRANSFERENCIA	", 12m),
            new Retirada("9E450000-67A0-641C-9D22-08D8C530FE5A", "TRASFERENCIA II", 36m),
            new Retirada("9E450000-67A0-641C-AA77-08D8C530FE5A", "PAG. CONTA CARTÃO DIGIO",  100.00m),
        };

        private static readonly Deposito[] Depositos = new Deposito[]
        {
                new Deposito("9E450000-67A0-641C-844F-08D8C530FE5A", "DEPOSITO CONTA BRADESCO", 532),
                new Deposito("9E450000-67A0-641C-844F-08D8C530FE5A", "DEPOSITO CONTA BRADESCO", 2100),
                new Deposito("9E450000-67A0-641C-844F-08D8C530FE5A", "DEPOSITO CONTA BRADESCO", 1760),
                new Deposito("9E450000-67A0-641C-844F-08D8C530FE5A", "DEPOSITO CONTA BRADESCO", 945 ),
                new Deposito("9E450000-67A0-641C-9D22-08D8C530FE5A", "DEPOSITO CONTA NUBANK", 600),
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
