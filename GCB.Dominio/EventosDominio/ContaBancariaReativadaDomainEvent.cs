using GCB.Dominio.ObjetosValor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Dominio.EventosDominio
{
    public class ContaBancariaReativadaDomainEvent : INotification
    {
        public Guid ContaBancariaId { get; private set; }
        public Real DiferencaSaldoAnterior { get; private set; }

        public ContaBancariaReativadaDomainEvent(Guid contaBancariaId, Real diferenca)
        {
            ContaBancariaId = contaBancariaId;
            DiferencaSaldoAnterior = diferenca;
        }
    }
}
