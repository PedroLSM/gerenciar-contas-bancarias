using GCB.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Consultas.Referencias.ObterReferenciasAgrupadaPorAno
{
    public class ReferenciasAgrupadaPorAnoDto
    {
        public int AnoReferencia { get; private set; }
        public IEnumerable<ReferenciaDto> Meses { get; private set; }

        public ReferenciasAgrupadaPorAnoDto(int anoReferencia, IList<ReferenciaDto> meses)
        {
            AnoReferencia = anoReferencia;
            Meses = meses;
        }
    }

    public class ReferenciaDto
    {
        public Guid Id { get; set; }
        public int AnoReferencia { get; set; }
        public string MesReferencia { get; set; }
        public decimal TotalRetirado { get; set; }
        public decimal TotalDepositado { get; set; }
        public decimal DiferencaSaldoAnterior { get; set; }
        public decimal Saldo { get; set; }

        public ReferenciaDto(Guid id, int anoReferencia, string mesReferencia, decimal totalRetirado, decimal totalDepositado, decimal diferencaSaldoAnterior, decimal saldo)
        {
            Id = id;
            AnoReferencia = anoReferencia;
            MesReferencia = mesReferencia;
            TotalRetirado = totalRetirado;
            TotalDepositado = totalDepositado;
            DiferencaSaldoAnterior = diferencaSaldoAnterior;
            Saldo = saldo;
        }
    }
}
