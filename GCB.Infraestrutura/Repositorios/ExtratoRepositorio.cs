using GCB.Comum.Repositorios;
using GCB.Dominio.Entidades;
using GCB.Dominio.Repositorios;

namespace GCB.Infraestrutura.Repositorios
{
    public class ExtratoRepositorio : Repository<Extrato>, IExtratoRepositorio    
    {
        public ExtratoRepositorio(GerenciarContasBancariasContext context) 
            : base(context)
        {
        }
    }
}
