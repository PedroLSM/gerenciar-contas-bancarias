using GCB.Comum.Notificacoes;
using GCB.Dominio.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Dominio.EventosDominio
{
    public class ReferenciaCriadaDomainEvent : INotification
    {
        public Guid ReferenciaId { get; private set; }

        public ReferenciaCriadaDomainEvent(Guid referenciaId)
        {
            ReferenciaId = referenciaId;
        }
    }

    public class CalcularDiferencaSaldoDomainEvent : INotification
    {
        public CalcularDiferencaSaldoDomainEvent()
        {
        }

        //public Guid ReferenciaId { get; private set; }
        //public Mes MesReferencia { get; private set; }
        //public int AnoReferencia { get; private set; }

        //public (Mes mes1, int ano1) AnoMesReferenciaAtual => MesReferencia - 1 <= 0 ? (MesReferencia + 11, AnoReferencia - 1) : (MesReferencia - 1, AnoReferencia);
        //public (Mes mes1, int ano1) AnoMesReferenciaAnterior => MesReferencia - 2 <= 0 ? (MesReferencia + 10, AnoReferencia - 1) : (MesReferencia - 2, AnoReferencia);

        //public CalcularDiferencaSaldoDomainEvent(Guid referenciaId, Mes mesReferencia, int anoReferencia)
        //{
        //    ReferenciaId = referenciaId;
        //    MesReferencia = mesReferencia;
        //    AnoReferencia = anoReferencia;
        //}
    }
}
