﻿using GCB.Comum.Repositorios;
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
    public class ReferenciaRepositorio : Repository<Referencia>, IReferenciaRepositorio
    {
        public ReferenciaRepositorio(GerenciarContasBancariasContext context)
            : base(context)
        {
        }

        public async Task<bool> ReferenciaExiste(Mes mesReferencia)
        {
            return await Context.Set<Referencia>()
                .AnyAsync(r => r.Ano == DateTime.Now.Year && r.Mes == mesReferencia);
        }
    }
}