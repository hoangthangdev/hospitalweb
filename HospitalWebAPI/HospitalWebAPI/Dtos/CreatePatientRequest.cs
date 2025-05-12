namespace HospitalWebAPI.Dtos;

public record CreatePatientRequest(string name, DateTime birthDay, string Address);
