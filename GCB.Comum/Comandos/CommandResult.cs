using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace GCB.Comum.Comandos
{
    public class CommandResult
    {
        public HttpStatusCode Status { get; private set; }
        public string Mensagem { get; private set; }
        public string UnknownException { get; set; }
        public object Dados { get; private set; }

        public CommandResult(HttpStatusCode statusCode, string mensagem, object dados)
        {
            Status = statusCode;
            Mensagem = mensagem;
            Dados = dados;
        }

        public CommandResult(string mensagem, string unknownException)
        {
            Dados = null;
            Mensagem = mensagem;
            UnknownException = unknownException;
            Status = HttpStatusCode.InternalServerError;
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
