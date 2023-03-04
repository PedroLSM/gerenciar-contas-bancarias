using System;
using System.Globalization;

namespace GCB.Dominio.DTOs
{
    public class CsvExtratoDTO
    {
        public string Data { get; set; }
        public DateTime DataFormatada
        {
            get
            {
                try
                {
                    return DateTime.ParseExact(Data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    try
                    {
                        return DateTime.ParseExact(Data, "dd/MM/yy", CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        return DateTime.Now;
                    }
                }
            }
        }

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set => _descricao = value.Length > 100 ? value[..100] : value;
        }

        public string Valor { get; set; }
        public decimal ValorFormatado =>
            decimal.Parse(Valor.Replace(".", ","));
    }
}
