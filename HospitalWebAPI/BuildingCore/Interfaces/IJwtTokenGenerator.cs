using BuildingCore.Data.Identity;

namespace BuildingCore.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
