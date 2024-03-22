using MediatR;
using System.Collections.Generic;

namespace GCB.Aplicacao.Consultas.Emprestimos.ObterEmprestimos
{
    public class ObterEmprestimosQuery : IRequest<IEnumerable<ObterEmprestimosDto>>
    {

    }
}
