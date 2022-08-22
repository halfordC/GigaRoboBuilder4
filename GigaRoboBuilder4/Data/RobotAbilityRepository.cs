using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaRoboBuilder4.Data
{
    public static class RobotAbilityRepository
    {
        public static async Task<List<RobotAbility>> GetRobotAbilitiesAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.RobotAbilities.ToListAsync();
            }
        }

        public static async Task<RobotAbility> GetRobotAbilityByIdAsync(int RobotAbilityId)
        {
            using (var db = new AppDbContext())
            {
                return await db.RobotAbilities.FirstOrDefaultAsync(robotAbility => robotAbility.Id == RobotAbilityId);
            }
        }

        //There is probably a more efficient way to do this, but I don't know what that is yet.
        //The datasets are small enough where I don't think it would make a huge difference.
        public static async Task<List<RobotAbility>> GetRobotAbilitiesByRobotIdAsync(int RobotInId)
        {
            using (var db = new AppDbContext())
            {
                List<RobotAbility> allAbilities = await GetRobotAbilitiesAsync();
                List<RobotAbility> returnList = new List<RobotAbility>();
                foreach (var robotAbility in allAbilities)
                {
                    if (robotAbility.RobotId == RobotInId)
                    {
                        returnList.Add(robotAbility);
                    }
                }
                return returnList;
            }
        }

        public static async Task<bool> CreateRobotAbilityAsync(RobotAbility RobotAbilityToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.RobotAbilities.AddAsync(RobotAbilityToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> UpdateRobotAbilityAsync(RobotAbility RobotAbilityToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.RobotAbilities.Update(RobotAbilityToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> DeleteRobotAbilityAsync(int RobotAbilityId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    RobotAbility robotAbilityToDelete = await GetRobotAbilityByIdAsync(RobotAbilityId);
                    db.RobotAbilities.Remove(robotAbilityToDelete);
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
