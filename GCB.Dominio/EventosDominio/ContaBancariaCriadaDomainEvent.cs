using GCB.Dominio.ObjetosValor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Dominio.EventosDominio
{
    public class ContaBancariaCriadaDomainEvent : INotification
    {
        public Guid Id { get; private set; }
        public Real SaldoAtual { get; private set; }

        public ContaBancariaCriadaDomainEvent(Guid contaId, Real saldoAtual)
        {
            Id = contaId;
            SaldoAtual = saldoAtual;
        }
    }
}
