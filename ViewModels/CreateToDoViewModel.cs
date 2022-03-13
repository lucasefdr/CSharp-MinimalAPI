using Flunt.Notifications;
using Flunt.Validations;

public class CreateToDoViewModel : Notifiable<Notification>
{
    public string Title { get; set; }

    public ToDo MapTo()
    {
        AddNotifications(new Contract<Notification>()
        .Requires()
        .IsNotNull(Title, "Informe o título da tarefa:")
        .IsGreaterThan(Title, 5, "O título deve conter mais de 5 caracteres."));

        return new ToDo(Guid.NewGuid(), Title, false);
    }
}
