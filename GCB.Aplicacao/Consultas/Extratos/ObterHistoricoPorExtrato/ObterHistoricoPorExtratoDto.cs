using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterHistoricoPorExtrato
{
    public class ObterHistoricoPorExtratoDto
    {
		public Guid OperacaoId { get; set; }
		public Guid ExtratoId { get; set; }
		public string Descricao { get; set; }
		public decimal Valor { get; set; }
		public DateTime DataRegistro { get; set; }
		public string TipoOperacao { get; set; }
    }
}
