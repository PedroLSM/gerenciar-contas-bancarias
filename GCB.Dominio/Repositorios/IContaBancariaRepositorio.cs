using GCB.Comum.Repositorios;
using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using System.Threading.Tasks;

namespace GCB.Dominio.Repositorios
{
    public interface IContaBancariaRepositorio : IRepository<ContaBancaria>
    {
        Task<bool> ContaBancariaExiste(string nomeConta, TipoConta tipoConta);
    }
}