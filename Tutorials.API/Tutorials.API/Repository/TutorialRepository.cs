using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorials.API.DAL;
using Microsoft.EntityFrameworkCore;
using Tutorials.API.Model;

namespace Tutorials.API.Repository
{
    public class TutorialRepository : ITutorialRespository
    {
        private readonly TutorialContext _context;

        public TutorialRepository(TutorialContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tutorial>> GetTutorials()
        {
            return await _context.Tutorials.ToListAsync();
        }

        public async Task<Tutorial> GetTutorial(int id)
        {
           return await _context.Tutorials.FindAsync(id);
        }

        public async Task UpdateTutorial(Tutorial tutorial)
        {
            _context.Entry(tutorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorialExists(tutorial.Id))
                {
                    throw new ApplicationException($"Tutorial with {tutorial.Id} does not exist");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Tutorial> CreateTutorial(Tutorial tutorial)
        {
            _context.Tutorials.Add(tutorial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return tutorial;
        }

        public async Task<Tutorial> DeleteTutorial(int id)
        {
            var tutorial = await _context.Tutorials.FindAsync(id);
            if (tutorial == null)
            {
                throw new ApplicationException($"Tutorial with {id} does not exist");
            }

            _context.Tutorials.Remove(tutorial);
            await _context.SaveChangesAsync();

            return tutorial;
        }

        private bool TutorialExists(int id)
        {
            return _context.Tutorials.Any(e => e.Id == id);
        }
    }
}
