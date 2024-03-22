using MediatR;
using System;
using System.Collections.Generic;

namespace GCB.Aplicacao.Consultas.Emprestimos.ObterPagamentosPorEmprestimo
{
    public class ObterPagamentosPorEmprestimoQuery : IRequest<IEnumerable<ObterPagamentosPorEmprestimoDto>>
    {
        public Guid EmprestimoId { get; set; }
    }
}
