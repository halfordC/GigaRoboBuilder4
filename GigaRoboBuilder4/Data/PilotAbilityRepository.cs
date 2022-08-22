using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaRoboBuilder4.Data
{
    public class PilotAbilityRepository
    {
        public static async Task<List<PilotAbility>> GetPilotAbilitiesAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.PilotAbilities.ToListAsync();
            }

        }
        public static async Task<PilotAbility> GetPilotAbilityByIdAsync(int PilotAbilityId)
        {
            using (var db = new AppDbContext())
            {
                return await db.PilotAbilities.FirstOrDefaultAsync(pilotAbility => pilotAbility.Id == PilotAbilityId);
            }
        }

        public static async Task<List<PilotAbility>> GetPilotAbilitiesByPilotIdAsync(int PilotInId)
        {
            using (var db = new AppDbContext())
            {
                List<PilotAbility> allAbilities = await GetPilotAbilitiesAsync();
                List<PilotAbility> returnList = new List<PilotAbility>();
                foreach (var pilotAbility in allAbilities)
                {
                    if (pilotAbility.PilotId == PilotInId)
                    {
                        returnList.Add(pilotAbility);
                    }
                }
                return returnList;
            }
        }

        public static async Task<bool> UpdatePilotAbilityAsync(PilotAbility PilotAbilityToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.PilotAbilities.Update(PilotAbilityToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static async Task<bool> DeletePilotAbilityAsync(int PilotAbilityId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    PilotAbility PilotAbilityToDelete = await GetPilotAbilityByIdAsync(PilotAbilityId);
                    db.PilotAbilities.Remove(PilotAbilityToDelete);
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
