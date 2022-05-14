using GCB.Comum.Comandos;
using GCB.Comum.Extensoes;
using GCB.Dominio.Enums;
using MediatR;

namespace GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia
{
    public class AdicionarReferenciaCommand : IRequest<CommandResult>
    {
        public Mes MesReferencia { get; private set; }

        public AdicionarReferenciaCommand(string mesReferencia)
        {
            MesReferencia = mesReferencia.ParseEnum<Mes>();;
        }
    }
}
