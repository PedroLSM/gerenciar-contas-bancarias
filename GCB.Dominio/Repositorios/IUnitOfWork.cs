using System.Threading;
using System.Threading.Tasks;

namespace GCB.Dominio.Repositorios
{
    public interface IUnitOfWork
    {
        IReferenciaRepositorio Referencia { get; }
        IExtratoRepositorio Extrato { get; }
        IContaBancariaRepositorio ContaBancaria { get; }
        IEmprestimoRepositorio Emprestimo { get; }

        Task SaveChanges(CancellationToken cancellationToken = default);
    }
}
