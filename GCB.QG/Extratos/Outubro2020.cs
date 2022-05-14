using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GCB.QG.Extratos
{
    public static class Outubro2020
    {
        private static readonly Retirada[] Retiradas = new Retirada[]
        {
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "CONTA AGUA", 42.94m),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "CONTA DE AGUA II", 61.10m),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "BAN BAN CALÇADOS", 299.80m ),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "PAGAMENTO INTERNET", 79.90m   ),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "CONTA DE LUZ", 149.89m),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "CONTA DE AGUA III", 45.57m ),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "CONTA DIGIO ANDRE", 195.54m ),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "CONTA NUBANK ANDRE", 488.20m),
            new Retirada("9E450000-67A0-641C-4971-08D8C531AA3B", "PAGAMENTO INTERNET II", 55m),
            new Retirada("9E450000-67A0-641C-C0EB-08D8C531AA3B", "PAGAMENTO NUBANK", 619.95m),
            new Retirada("9E450000-67A0-641C-C0EB-08D8C531AA3B", "PAGAMENTO NUBANK II", 313.67m),
            new Retirada("9E450000-67A0-641C-C0EB-08D8C531AA3B", "PAGAMENTO NUBANK III", 671.89m),
            new Retirada("9E450000-67A0-641C-C91B-08D8C531AA3B", "PAGAMENTO DIGIO", 195.10m)
        };

        private static readonly Deposito[] Depositos = new Deposito[]
        {
                new Deposito("9E450000-67A0-641C-4971-08D8C531AA3B", "DEPOSITO CONTA BRADESCO", 1618.68m),
                new Deposito("9E450000-67A0-641C-4971-08D8C531AA3B", "DEPOSITO CONTA BRADESCO", 400 ),
                new Deposito("9E450000-67A0-641C-4971-08D8C531AA3B", "DEPOSITO CONTA BRADESCO", 400 ),
                new Deposito("9E450000-67A0-641C-4971-08D8C531AA3B", "DEPOSITO CONTA BRADESCO", 1300 ),
                new Deposito("9E450000-67A0-641C-4971-08D8C531AA3B", "DEPOSITO CONTA BRADESCO", 50),
        };

        public static async Task AdicionarExtratoAsync(HttpClient httpClient)
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
