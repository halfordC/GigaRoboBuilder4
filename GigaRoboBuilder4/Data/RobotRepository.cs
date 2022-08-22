using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaRoboBuilder4.Data
{
    public static class RobotRepository
    {
        public static async Task<List<Robot>> GetRobotsAsync() 
        {
            using (var db = new AppDbContext()) 
            {
                return await db.Robots.ToListAsync();
            }
                
        }

        public static async Task<Robot> GetRobotById(int RobotId) 
        {
            using (var db = new AppDbContext()) 
            {
                return await db.Robots.FirstOrDefaultAsync(robot => robot.Id == RobotId);
            }

        }

        public static async Task<bool> CreateRobotAsync(Robot RobotToCreate) 
        {
            using (var db = new AppDbContext()) 
            {
                try
                {
                    await db.Robots.AddAsync(RobotToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> UpdateRobotAsync(Robot RobotToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {   
                    db.Robots.Update(RobotToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> DeleteRobotAsync(int RobotId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    Robot robotToDelete = await GetRobotById(RobotId);
                    db.Robots.Remove(robotToDelete);
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
