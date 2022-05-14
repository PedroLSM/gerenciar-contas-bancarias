using FluentValidation.Results;
using GCB.Comum.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCB.Comum.Excecoes
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Um ou mais erros de validaçao foram encontrados.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IReadOnlyCollection<Notification> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.Key, e => e.Message);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
