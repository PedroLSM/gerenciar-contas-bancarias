using GCB.Dominio.ObjetosValor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Dominio.EventosDominio
{
    public class DepositoBancarioRealizadoDomainEvent : INotification
    {
        public Guid DepositoId { get; private set; }
        public Guid ReferenciaId { get; private set; }
        public Guid ContaBancariaId { get; private set; }
        public Real Valor { get; private set; }

        public DepositoBancarioRealizadoDomainEvent(Guid depositoId, Guid referenciaId, Guid contaBancariaId, Real valor)
        {
            DepositoId = depositoId;
            ReferenciaId = referenciaId;
            ContaBancariaId = contaBancariaId;
            Valor = valor;
        }
    }
}
