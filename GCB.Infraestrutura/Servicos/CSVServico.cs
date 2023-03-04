using CsvHelper;
using CsvHelper.Configuration;
using GCB.Dominio.Servicos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GCB.Infraestrutura.Servicos
{
    public class CSVServico : ICSVServico
    {
        public IList<T> LerCSV<T>(Stream file)
        {
            using var reader = new StreamReader(file);

            var ptBR = new CultureInfo("pt-BR");
            var config = new CsvConfiguration(ptBR)
            {
                DetectDelimiter = true
            };
           
            using var csv = new CsvReader(reader, config);

            var records = csv.GetRecords<T>();

            return records.ToList();
        }

        public IList<T> LerCSV<T>(IFormFile file)
        {
            using var stream = file.OpenReadStream();

            return LerCSV<T>(stream);
        }
    }
}
