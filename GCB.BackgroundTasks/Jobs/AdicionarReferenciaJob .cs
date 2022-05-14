using GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia;
using GCB.Comum.Excecoes;
using GCB.Dominio.Enums;
using GCB.Dominio.Repositorios;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GCB.BackgroundTasks.Jobs
{
    public interface IAdicionarReferenciaJob
    {
        Task RunAtTimeOf(DateTime now);
    }

    public class AdicionarReferenciaJob : IAdicionarReferenciaJob
    {
        private readonly ILogger<AdicionarReferenciaJob> logger;
        private readonly IMediator mediator;

        public AdicionarReferenciaJob(
            ILogger<AdicionarReferenciaJob> logger,
            IMediator mediator
        )
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public async Task RunAtTimeOf(DateTime now)
        {
            logger.LogInformation("Referência Job Iniciado...");
            
            Mes mesAtual = (Mes) now.Month;
            logger.LogInformation($"Adicionar mês de refêrencia {mesAtual} para o ano {now.Year}");

            try
            {
                var response = await mediator.Send(new AdicionarReferenciaCommand(mesAtual.ToString()));
                
                if ((int)response.Status >= 200 && (int)response.Status < 300)
                {
                    logger.LogInformation("Ocorreu a virada do mês...");
                    logger.LogInformation("referência para o mês: {Mes}, foi adicionada...", mesAtual.ToString());
                }
                else
                {
                    logger.LogInformation("Ainda não ocorreu a virada do mês, referência não adicionada...");
                }

                logger.LogInformation("Referência Job Completo...");
            }
            catch (ValidationException ve)
            {
                logger.LogInformation("Ainda não ocorreu a virada do mês, referência não adicionada...");
                
                foreach (var error in ve.Errors)
                    logger.LogInformation("{Key} - {Value}", error.Key, error.Value);
                
            }
            catch
            {
                throw;
            }
            
            
        }
    }
}
