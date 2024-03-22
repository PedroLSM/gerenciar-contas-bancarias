using GCB.Comum.Comandos;
using GCB.Dominio.Entidades;
using GCB.Dominio.ObjetosValor;
using GCB.Dominio.Repositorios;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GCB.Aplicacao.Comandos.Extratos.RealizarRetiradaBancaria
{
    public class RealizarRetiradaBancariaHandler : IRequestHandler<RealizarRetiradaBancariaCommand, CommandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public RealizarRetiradaBancariaHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(RealizarRetiradaBancariaCommand request, CancellationToken cancellationToken)
        {
            Extrato extrato, extratoTransferencia = null;

            switch (request.TipoRetirada)
            {
                case Dominio.Enums.TipoRetirada.Retirada:
                    (extrato, _) = RealizarRetirada(request);
                    break;
                case Dominio.Enums.TipoRetirada.Transferencia:
                    (extrato, extratoTransferencia) = RealizarTransferencia(request);
                    break;
                default:
                    return new CommandResult(HttpStatusCode.BadRequest, "Tipo de Retirada Indisponível", new { request.TipoRetirada });
            }

            await unitOfWork.SaveChanges(cancellationToken);

            return new CommandResult(HttpStatusCode.Created, $"{request.TipoRetirada} realizada", new
            {
                ExtratoId = extrato?.Id,
                Saldo = extrato?.Saldo.Valor,
                TotalDepositado = extrato?.TotalDepositado.Valor,
                TotalRetirado = extrato?.TotalRetirado.Valor,

                ExtratoContaTransferencia = new
                {
                    ExtratoId = extratoTransferencia?.Id,
                    Saldo = extratoTransferencia?.Saldo.Valor,
                    TotalDepositado = extratoTransferencia?.TotalDepositado.Valor,
                    TotalRetirado = extratoTransferencia?.TotalRetirado.Valor,
                }
            });
        }

        (Extrato, ContaBancaria) RealizarRetirada(RealizarRetiradaBancariaCommand request)
        {
            var extrato = unitOfWork.Extrato.GetSingle(request.ExtratoId);

            var contaBancaria = unitOfWork.ContaBancaria.GetSingle(extrato.ContaBancariaId);

            var retiradaBancaria = request.Data.HasValue ?             
                new RetiradaBancaria(request.ExtratoId, request.Descricao, new Real(request.Valor), request.Data.Value.Date) :
                new RetiradaBancaria(request.ExtratoId, request.Descricao, new Real(request.Valor));

            extrato.AdicionarRetirada(retiradaBancaria, contaBancaria);

            unitOfWork.Extrato.Update(extrato);

            return (extrato, contaBancaria);
        }

        (Extrato, Extrato) RealizarTransferencia(RealizarRetiradaBancariaCommand request)
        {
            var (extrato, contaBancaria) = RealizarRetirada(request);

            var extratoTransferencia = unitOfWork.Extrato.GetSingle(request.ExtratoTransferenciaId);
            var contaBancariaTransferencia = unitOfWork.ContaBancaria.GetSingle(extratoTransferencia.ContaBancariaId);

            var depositoBancario = request.Data.HasValue ?
                new DepositoBancario(request.ExtratoTransferenciaId.Value, $"[Transferência {contaBancaria.NomeBanco}] - {request.Descricao}", new Real(request.Valor), request.Data.Value.Date) :
                new DepositoBancario(request.ExtratoTransferenciaId.Value, $"[Transferência {contaBancaria.NomeBanco}] - {request.Descricao}", new Real(request.Valor));

            extratoTransferencia.AdicionarDeposito(depositoBancario, contaBancariaTransferencia);

            unitOfWork.Extrato.Update(extratoTransferencia);

            return (extrato, extratoTransferencia);
        }
    }
}
