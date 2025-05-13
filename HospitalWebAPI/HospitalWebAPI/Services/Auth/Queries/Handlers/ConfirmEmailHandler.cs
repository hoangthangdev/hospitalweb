using BuildingCore.CQRS;


namespace HospitalWebAPI.Services.Auth.Queries.Handlers
{
    public record ConfirmEmailQuery(string UserID, string Token) : IQuery<ConfirmEmailResult>;
    public record ConfirmEmailResult(bool IsSuccess);
    public class ConfirmEmailHandler : IQueryHandler<ConfirmEmailQuery, ConfirmEmailResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ConfirmEmailHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ConfirmEmailResult> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserID);
            if (user is null)
            {
                return new ConfirmEmailResult(false);
            }
            var decodedToken = Uri.UnescapeDataString(request.Token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (result.Succeeded)
            {
                return new ConfirmEmailResult(true);
            }
            else
            {
                return new ConfirmEmailResult(false);
            }
        }
    }
}
