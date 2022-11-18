using GCB.QG.Extratos;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace GCB.QG
{
    public class Program
    {

        public static string Diretorio { get; private set; }

        public static async Task Main(string[] args)
        {
            Diretorio = Directory.GetCurrentDirectory();

            Console.Title = "Gerenciar Contas Bancarias QG [Contas 2020]";

            Console.WriteLine("==========================================");
            Console.WriteLine(Diretorio);
            Console.WriteLine("==========================================");

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:5257/")
            };

            await Agosto2020.AdicionarExtratoAsync(httpClient);
            await Setembro2020.AdicionarExtratoAsync(httpClient);
            await Outubro2020.AdicionarExtratoAsync(httpClient);
            await Novembro2020.AdicionarExtratoAsync(httpClient);
            await Dezembro2020.AdicionarExtratoAsync(httpClient);
            await Janeiro2021.AdicionarExtratoAsync(httpClient);
        }
    }
}
