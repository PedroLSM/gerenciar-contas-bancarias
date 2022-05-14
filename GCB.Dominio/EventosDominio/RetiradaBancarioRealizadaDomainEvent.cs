using GCB.Dominio.ObjetosValor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Dominio.EventosDominio
{
    public class RetiradaBancariaRealizadaDomainEvent : INotification
    {
        public Guid ContaBancariaId { get; private set; }
        public Real Valor { get; private set; }
        public Guid RetiradaId { get; private set; }
        public Guid ReferenciaId { get; private set; }

        public RetiradaBancariaRealizadaDomainEvent(Guid retiradaId, Guid referenciaId, Guid contaBancariaId, Real valor)
        {
            RetiradaId = retiradaId;
            ReferenciaId = referenciaId;
            ContaBancariaId = contaBancariaId;
            Valor = valor;
        }
    }
}
