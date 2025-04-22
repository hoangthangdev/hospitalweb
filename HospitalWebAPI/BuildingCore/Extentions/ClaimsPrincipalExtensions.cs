using System.Security.Claims;

namespace BuildingCore.Extentions
{
    public static class ClaimsPrincipalExtensions
    {
        public static long? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            if (userId is null)
            {
                return -1;
            }
            return long.TryParse(userId.Value, out long id) ? id : null;
        }
        public static string? GetUserName(this ClaimsPrincipal claimsPrincipal)
        {
            var userName = claimsPrincipal.FindFirst(ClaimTypes.Name);
            return userName is not null ? userName.Value : "no";
        }
    }
}
