namespace BuildingCore.Interfaces
{
    public interface IEmailSender<T> where T : class
    {
        Task SendEmailAsync(T user, string subject, string htmlMessage);
    }
}
