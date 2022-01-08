using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.SailCamp;
using eGertis.Models;

namespace eGertis.Services.SailCamps
{
    public interface ISailCampService
    {
        Task<ServiceResponse<List<GetSailCampDto>>> GetAllSailCamps();
        Task<ServiceResponse<GetSailCampDto>> GetSailCapmById(int id);
        Task<ServiceResponse<List<GetSailCampDto>>> CreateSailCamp(CreateSailCampDto sailCampDto);
        Task<ServiceResponse<List<GetSailCampDto>>> UpdateSailCamp(UpdateSailCampDto sailCampDto);
        Task<ServiceResponse<List<GetSailCampDto>>> RemoveSailCamp(int id);

    }
}