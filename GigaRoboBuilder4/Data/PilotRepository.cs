using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaRoboBuilder4.Data
{
    public class PilotRepository
    {
        public static async Task<List<Pilot>> GetPilotsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Pilots.ToListAsync();
            }
        }

        public static async Task<Pilot> GetPilotByIdAsync(int PilotId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Pilots.FirstOrDefaultAsync(pilot => pilot.Id == PilotId);
            }
        }

        public static async Task<bool> CreatePilotAsync(Pilot PilotToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.Pilots.AddAsync(PilotToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> UpdatePilotAsync(Pilot PilotToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Pilots.Update(PilotToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> DeletePilotAsync(int PilotId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    Pilot pilotToDelete = await GetPilotByIdAsync(PilotId);
                    db.Pilots.Remove(pilotToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}
