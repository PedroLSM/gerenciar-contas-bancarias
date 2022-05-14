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
        public Mes MesReferencia { get; private set; }
        public int AnoReferencia { get; private set; }

        public ReferenciaCriadaDomainEvent(Guid referenciaId, Mes mesReferencia, int anoReferencia)
        {
            ReferenciaId = referenciaId;
            MesReferencia = mesReferencia;
            AnoReferencia = anoReferencia;
        }
    }
}
