using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCB.Comum.Notificacoes
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool Valid => !_notifications.Any();
        public bool Invalid => _notifications.Any();

        public Notifiable()
        {
            _notifications ??= new List<Notification>();
        }

        public async Task<bool> ValidateAsync<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
                AddNotifications(validationResult);

            return Valid;
        }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
                AddNotifications(validationResult);

            return Valid;
        }

        public void AddNotifications(params Notifiable[] models)
        {
            foreach (var model in models)
            {
                AddNotifications(model.Notifications);
            }
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
