namespace BuildingCore.Common
{
    public static class Constants
    {
        public static class RoleConstants
        {
            public const string Admin = "Admin";
            public const string Doctor = "Doctor";
            public const string Patient = "Patient";

            public static readonly string[] AllRoles = { Admin, Doctor, Patient };
        }
    }
}
