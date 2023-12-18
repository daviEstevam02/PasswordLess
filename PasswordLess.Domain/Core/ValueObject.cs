using Flunt.Notifications;

namespace PasswordLess.Domain.Core;

public abstract class ValueObject: Notifiable<Notification>
{
    protected abstract void Validate();
}