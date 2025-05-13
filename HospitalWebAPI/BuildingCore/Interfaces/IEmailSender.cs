namespace BuildingCore.Interfaces
{
    public interface IEmailSenderCustomer<T> where T : class
    {
        Task SendEmailAsync(T user, string subject, string htmlMessage);
    }
}
