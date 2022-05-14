using System.Threading;
using System.Threading.Tasks;

namespace GCB.Dominio.Repositorios
{
    public interface IUnitOfWork
    {
        IReferenciaRepositorio Referencia { get; }
        IExtratoRepositorio Extrato { get; }
        IContaBancariaRepositorio ContaBancaria { get; }

        Task SaveChanges(CancellationToken cancellationToken = default);
    }
}
