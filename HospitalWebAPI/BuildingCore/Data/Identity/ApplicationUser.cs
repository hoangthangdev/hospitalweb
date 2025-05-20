using Microsoft.AspNetCore.Identity;
using static BuildingCore.Common.Status;

namespace BuildingCore.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public StatusGender Gender { get; set; }
        public StatusUser Status { get; set; }
    }
}
