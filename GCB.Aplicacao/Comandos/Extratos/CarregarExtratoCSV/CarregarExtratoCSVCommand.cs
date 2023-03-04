using GCB.Comum.Comandos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace GCB.Aplicacao.Comandos.Extratos.CarregarExtratoCSV
{
    public class CarregarExtratoCSVCommand : IRequest<CommandResult>
    {
        public Guid ExtratoId { get; set; }
        public IFormFile Arquivo { get; set; }

        //public CarregarExtratoCSVCommand(Guid extratoId, IFormFile arquivo)
        //{
        //    ExtratoId = extratoId;
        //    Arquivo = arquivo;
        //}
    }
}
