using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaRoboBuilder4.Data
{
    public class PilotCardRepository
    {
        public static async Task<List<PilotCard>> GetPilotCardsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.PilotCards.ToListAsync();
            }

        }
        public static async Task<PilotCard> GetPilotCardByIdAsync(int PilotCardId)
        {
            using (var db = new AppDbContext())
            {
                return await db.PilotCards.FirstOrDefaultAsync(pilotCard => pilotCard.Id == PilotCardId);
            }
        }
        public static async Task<List<PilotCard>> GetPilotCardsByPilotIdAsync(int PilotInId)
        {
            using (var db = new AppDbContext())
            {
                List<PilotCard> allCards = await GetPilotCardsAsync();
                List<PilotCard> returnList = new List<PilotCard>();
                foreach (var pilotCard in allCards)
                {
                    if (pilotCard.PilotId == PilotInId)
                    {
                        returnList.Add(pilotCard);
                    }
                }
                return returnList;
            }
        }

        public static async Task<bool> CreatePilotCardAsync(PilotCard PilotCardToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.PilotCards.AddAsync(PilotCardToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> UpdatePilotCardAsync(PilotCard PilotCardToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.PilotCards.Update(PilotCardToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> DeletePilotCardAsync(int PilotCardId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    PilotCard pilotCardToDelete = await GetPilotCardByIdAsync(PilotCardId);
                    db.PilotCards.Remove(pilotCardToDelete);
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
