using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaRoboBuilder4.Data
{
    public static class RobotCardRepository
    {
        public static async Task<List<RobotCard>> GetRobotCardsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.RobotCards.ToListAsync();
            }

        }
        public static async Task<RobotCard> GetRobotCardByIdAsync(int RobotCardId)
        {
            using (var db = new AppDbContext())
            {
                return await db.RobotCards.FirstOrDefaultAsync(robotCard => robotCard.Id == RobotCardId);
            }
        }

        public static async Task<List<RobotCard>> GetRobotCardsByRobotIdAsync(int RobotInId)
        {
            using (var db = new AppDbContext())
            {
                List<RobotCard> allCards = await GetRobotCardsAsync();
                List<RobotCard> returnList = new List<RobotCard>();
                foreach(var robotCard in allCards) 
                {
                    if (robotCard.RobotId == RobotInId) 
                    {
                        returnList.Add(robotCard);
                    }
                }
                return returnList;
            }
        }

        public static async Task<bool> CreateRobotCardAsync(RobotCard RobotCardToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.RobotCards.AddAsync(RobotCardToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> UpdateRobotCardAsync(RobotCard RobotCardToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.RobotCards.Update(RobotCardToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> DeleteRobotCardAsync(int RobotCardId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    RobotCard robotCardToDelete = await GetRobotCardByIdAsync(RobotCardId);
                    db.RobotCards.Remove(robotCardToDelete);
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
