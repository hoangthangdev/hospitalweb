namespace HospitalWebAPI.Services.Auth.Commands.Responses
{
    public class RegisterResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
