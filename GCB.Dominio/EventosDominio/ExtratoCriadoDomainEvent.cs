using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Dominio.EventosDominio
{
    public class ExtratoCriadoDomainEvent : INotification
    {
        public Guid ExtratoId { get; private set; }

        public ExtratoCriadoDomainEvent(Guid id)
        {
            ExtratoId = id;
        }
    }
}
