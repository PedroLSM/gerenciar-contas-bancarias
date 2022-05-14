using GCB.Comum.Repositorios;
using GCB.Dominio.Entidades;
using GCB.Dominio.Enums;
using GCB.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Infraestrutura.Repositorios
{
    public class ContaBancariaRepositorio : Repository<ContaBancaria>, IContaBancariaRepositorio    
    {
        private readonly DbSet<ContaBancaria> dbSet;

        public ContaBancariaRepositorio(GerenciarContasBancariasContext context) 
            : base(context)
        {
            dbSet = context.Set<ContaBancaria>();
        }

        public async Task<bool> ContaBancariaExiste(string nomeBanco, TipoConta tipoConta)
        {
            return await dbSet.AnyAsync(e => e.NomeBanco == nomeBanco && e.TipoConta == tipoConta);
        }
    }
}
