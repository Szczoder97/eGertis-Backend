using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Dtos.SailCamp;
using eGertis.Models;
using eGertis.Repositories.SailCamps;

namespace eGertis.Services.SailCamps
{
    public class SailCampService : ISailCampService
    {
        private readonly ISailCampRepository _sailCampRepository;
        private readonly IMapper _mapper;

        public SailCampService(ISailCampRepository sailCampRepository, IMapper mapper)
        {
            _sailCampRepository = sailCampRepository;
            _mapper = mapper;
         
        }
        public async Task<ServiceResponse<List<GetSailCampDto>>> CreateSailCamp(CreateSailCampDto sailCampDto)
        {
            var response = new ServiceResponse<List<GetSailCampDto>>();
            var sailCamp = _mapper.Map<SailCamp>(sailCampDto);
            var camps = await _sailCampRepository.CreateSailCamp(sailCamp);
            response.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            return response;

        }

        public async Task<ServiceResponse<List<GetSailCampDto>>> EditSailCamp(EditSailCampDto sailCampDto)
        {
            var serviceResponse = new ServiceResponse<List<GetSailCampDto>>();
            var sailCamp = _mapper.Map<SailCamp>(sailCampDto);
            var camps = await _sailCampRepository.EditSailCamp(sailCamp);
            serviceResponse.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSailCampDto>>> GetAllSailCamps()
        {
            var serviceResponse = new ServiceResponse<List<GetSailCampDto>>();
            var camps = await _sailCampRepository.GetAllSailCamps();
            serviceResponse.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSailCampDto>> GetSailCapmById(int id)
        {
           var serviceResponse = new ServiceResponse<GetSailCampDto>();
           serviceResponse.Data = _mapper.Map<GetSailCampDto>(await _sailCampRepository.GetSailCampById(id));
           return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSailCampDto>>> RemoveSailCamp(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetSailCampDto>>();
            var camps = await _sailCampRepository.RemoveSailcamp(id);
            serviceResponse.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            return serviceResponse;
        }
    }
}