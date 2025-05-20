namespace HospitalWebAPI.Dtos;

public record CreatePatientRequest(string Email, string FullName, DateTime BirthDay, string Address, int UserId);
