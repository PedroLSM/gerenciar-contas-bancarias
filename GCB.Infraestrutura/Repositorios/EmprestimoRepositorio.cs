using GCB.Comum.Repositorios;
using GCB.Dominio.Entidades;
using GCB.Dominio.Repositorios;

namespace GCB.Infraestrutura.Repositorios
{
    public class EmprestimoRepositorio : Repository<Emprestimo>, IEmprestimoRepositorio
    {
        public EmprestimoRepositorio(GerenciarContasBancariasContext context)
            : base(context)
        {
        }
    }
}
