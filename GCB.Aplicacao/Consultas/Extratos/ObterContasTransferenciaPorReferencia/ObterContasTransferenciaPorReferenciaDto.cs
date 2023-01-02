using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Extratos.ObterContasTransferenciaPorReferencia
{
    public class ObterContasTransferenciaPorReferenciaDto
    {
		public Guid ExtratoId { get; set; }
		public Guid ContaBancariaId { get; set; }
		public Guid ReferenciaId { get; set; }
		public string NomeBanco { get; set; }
	}
}
