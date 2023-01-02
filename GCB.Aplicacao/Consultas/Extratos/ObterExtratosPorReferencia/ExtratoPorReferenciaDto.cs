using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterExtratosPorReferencia
{
    public class ObterHistoricoPorExtratoDto
    {
		public Guid ExtratoId { get; set; }
		public Guid ContaBancariaId { get; set; }
		public Guid ReferenciaId { get; set; }
		public string NomeBanco { get; set; }
		public decimal Saldo { get; set; }
		public decimal TotalDepositado { get; set; }
		public decimal TotalRetirado { get; set; }
		public bool Ativa { get; set; }
	}
}
