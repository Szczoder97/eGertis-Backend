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
            var serviceResponse = new ServiceResponse<List<GetSailCampDto>>();
            try
            {
                var sailCamp = _mapper.Map<SailCamp>(sailCampDto);
                var camps = await _sailCampRepository.CreateSailCamp(sailCamp);
                serviceResponse.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetSailCampDto>>> UpdateSailCamp(UpdateSailCampDto sailCampDto)
        {
            var serviceResponse = new ServiceResponse<List<GetSailCampDto>>();
            try
            {
                var sailCamp = _mapper.Map<SailCamp>(sailCampDto);
                var camps = await _sailCampRepository.UpdateSailCamp(sailCamp);
                serviceResponse.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSailCampDto>>> GetAllSailCamps()
        {
            var serviceResponse = new ServiceResponse<List<GetSailCampDto>>();
            try
            {
                var camps = await _sailCampRepository.GetAllSailCamps();
                serviceResponse.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSailCampDto>> GetSailCapmById(int id)
        {
            var serviceResponse = new ServiceResponse<GetSailCampDto>();
            try
            {
                serviceResponse.Data = _mapper.Map<GetSailCampDto>(await _sailCampRepository.GetSailCampById(id));
            }
            catch (Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSailCampDto>>> RemoveSailCamp(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetSailCampDto>>();
            try
            {
                var camps = await _sailCampRepository.RemoveSailcamp(id);
                serviceResponse.Data = camps.Select(c => _mapper.Map<GetSailCampDto>(c)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}