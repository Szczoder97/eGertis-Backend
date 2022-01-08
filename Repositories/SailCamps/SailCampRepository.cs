using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.SailCamps
{
    public class SailCampRepository : ISailCampRepository
    {
        private readonly DataContext _context;
        public SailCampRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SailCamp>> CreateSailCamp(SailCamp sailCamp)
        {
            _context.SailCamps.Add(sailCamp);
            await _context.SaveChangesAsync();
            return await GetAllSailCamps();
        }

        public async Task<List<SailCamp>> EditSailCamp(SailCamp sailCamp)
        {
            var campToEdit = await GetSailCampById(sailCamp.Id);
            campToEdit.Name = sailCamp.Name;
            await _context.SaveChangesAsync();
            return await GetAllSailCamps();
        }

        public async Task<List<SailCamp>> GetAllSailCamps()
        {
            return await _context.SailCamps.ToListAsync();
        }

        public async Task<SailCamp> GetSailCampById(int id)
        {
            return await _context.SailCamps.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<List<SailCamp>> RemoveSailcamp(int id)
        {
            var sailCamp = await GetSailCampById(id);
            _context.SailCamps.Remove(sailCamp);
            await _context.SaveChangesAsync();
            return await GetAllSailCamps();

        }
    }
}