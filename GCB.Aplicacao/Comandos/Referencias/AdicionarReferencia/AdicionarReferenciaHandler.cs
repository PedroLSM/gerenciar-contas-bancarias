using GCB.Comum.Comandos;
using GCB.Comum.Notificacoes;
using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia
{
    public class AdicionarReferenciaHandler 
        : IRequestHandler<AdicionarReferenciaCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public AdicionarReferenciaHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(AdicionarReferenciaCommand request, CancellationToken cancellationToken)
        {
            var ultimaReferencia = unitOfWork.Referencia.GetAll().LastOrDefault();

            var referencia = new Referencia(request.MesReferencia, ultimaReferencia);

            unitOfWork.Referencia.Add(referencia);

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, "Referência adicionada", new { referencia.Id });
        }
    }
}
