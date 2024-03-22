using System;

namespace GCB.Aplicacao.Consultas.Emprestimos.ObterPagamentosPorEmprestimo
{
    public class ObterPagamentosPorEmprestimoDto
    {
        public Guid Id { get; set; }
        public Guid EmprestimoId { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorPago { get; set; }
    }
}
