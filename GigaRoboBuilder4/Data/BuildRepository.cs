using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaRoboBuilder4.Data
{
    public class BuildRepository
    {
        public static async Task<List<Build>> GetBuildsAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Builds.ToListAsync();
            }

        }

        public static async Task<Build> GetBuildByIdAsync(int BuildId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Builds.FirstOrDefaultAsync(build => build.Id == BuildId);
            }
        }

        public static async Task<List<Build>> GetBuildByUserAsync(string UserName)
        {
            using (var db = new AppDbContext())
            {
                List<Build> allBuilds = await GetBuildsAsync();
                List<Build> returnList = new List<Build>();
                foreach (var build in allBuilds)
                {
                    if (build.Creator == UserName)
                    {
                        returnList.Add(build);
                    }
                }
                return returnList;
            }
        }

        public static async Task<bool> CreateBuildAsync(Build BuildToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.Builds.AddAsync(BuildToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> UpdateBuildAsync(Build BuildToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Builds.Update(BuildToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public static async Task<bool> DeleteBuildAsync(int BuildId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    Build buildToDelete = await GetBuildByIdAsync(BuildId);
                    db.Builds.Remove(buildToDelete);
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
