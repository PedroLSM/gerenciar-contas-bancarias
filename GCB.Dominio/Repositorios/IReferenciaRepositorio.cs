using GCB.Comum.Repositorios;
using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using System.Threading.Tasks;

namespace GCB.Dominio.Repositorios
{
    public interface IReferenciaRepositorio : IRepository<Referencia>
    {
        Task<bool> ReferenciaExiste(Mes mesReferencia);
    }
}