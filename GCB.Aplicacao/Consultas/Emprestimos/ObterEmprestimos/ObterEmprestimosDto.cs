using System;

namespace GCB.Aplicacao.Consultas.Emprestimos.ObterEmprestimos
{
    public class ObterEmprestimosDto
    {
        public Guid Id { get; set; }
        public string Devedor { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public decimal ValorEmprestimo { get; set; }
        public decimal ValorPrevisto { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorDevendo => ValorPrevisto - ValorPago;
    }
}
