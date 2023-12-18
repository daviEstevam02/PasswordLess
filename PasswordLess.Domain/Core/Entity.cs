using Flunt.Notifications;

namespace PasswordLess.Domain.Core;

public abstract class Entity: Notifiable<Notification>
{
    protected abstract void Validate();
}