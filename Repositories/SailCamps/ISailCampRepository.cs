using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.SailCamps
{
    public interface ISailCampRepository
    {
        Task<List<SailCamp>> CreateSailCamp(SailCamp sailCamp);
        Task<SailCamp> GetSailCampById(int id);
        Task<List<SailCamp>> GetAllSailCamps();
        Task<List<SailCamp>> UpdateSailCamp(SailCamp sailCamp);     
        Task<List<SailCamp>> RemoveSailcamp(int id);   
    }
}