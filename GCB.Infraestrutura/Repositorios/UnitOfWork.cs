using GCB.Dominio.Repositorios;
using GCB.Infraestrutura.Extensoes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Infraestrutura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GerenciarContasBancariasContext _context;
        private readonly IMediator _mediator;

        public UnitOfWork(GerenciarContasBancariasContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public IReferenciaRepositorio Referencia => new ReferenciaRepositorio(_context);
        public IExtratoRepositorio Extrato => new ExtratoRepositorio(_context);

        public IContaBancariaRepositorio ContaBancaria => new ContaBancariaRepositorio(_context);

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            
            await _mediator.DispatchDomainEventsAsync(_context, cancellationToken);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
