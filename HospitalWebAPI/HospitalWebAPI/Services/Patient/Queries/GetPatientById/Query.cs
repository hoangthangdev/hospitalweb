using BuildingBlocks.Pagination;
using BuildingCore.CQRS;
using BuildingCore.Pagination;
using HospitalWebAPI.Dtos;

namespace HospitalWebAPI.Services.Patient.Queries.GetPatientById
{
    public record GetPatientByIdQuery(GetByIdPatientRequest Request) : IQuery<GetPatientByIdResult>;

    public record GetPatientByIdResult(GetPatientByIdResponse Response);
}
