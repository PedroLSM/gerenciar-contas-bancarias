using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace GCB.Comum.Comandos
{
    public class CommandResult
    {
        public HttpStatusCode Status { get; private set; }
        public string Mensagem { get; private set; }
        public object Dados { get; private set; }

        public CommandResult(HttpStatusCode statusCode, string mensagem, object dados)
        {
            Status = statusCode;
            Mensagem = mensagem;
            Dados = dados;
        }

        public IActionResult ActionResult()
        {
            var result = new ObjectResult(this)
            {
                StatusCode = (int)Status
            };

            return result;
        }

        public static CommandResult BadResult(object dados)
        {
            return new CommandResult(
                statusCode: HttpStatusCode.BadRequest, 
                mensagem: "Contém um ou mais campos inválidos", 
                dados: dados
            );
        }
    }
}
