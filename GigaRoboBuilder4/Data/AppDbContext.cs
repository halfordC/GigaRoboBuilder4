using GigaRoboBuilder4.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GigaRoboBuilder4.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Robot> Robots { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<RobotAbility> RobotAbilities { get; set; }
        public DbSet<PilotAbility> PilotAbilities { get; set; }
        public DbSet<RobotCard> RobotCards { get; set; }
        public DbSet<PilotCard> PilotCards { get; set; }
        public DbSet<Build> Builds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOBuilder) => dbContextOBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var robotData = System.IO.File.ReadAllText("Data/SeedData/RobotSeedData.json");
            var robots = JsonSerializer.Deserialize<List<Robot>>(robotData);

            var pilotData = System.IO.File.ReadAllText("Data/SeedData/PilotSeedData.json");
            var pilots = JsonSerializer.Deserialize<List<Pilot>>(pilotData);

            var robotAbilityData = System.IO.File.ReadAllText("Data/SeedData/RobotAbilitySeedData.json");
            var robotAbilities = JsonSerializer.Deserialize<List<RobotAbility>>(robotAbilityData);

            var pilotAbilityData = System.IO.File.ReadAllText("Data/SeedData/PilotAbilitySeedData.json");
            var pilotAbilities = JsonSerializer.Deserialize<List<PilotAbility>>(pilotAbilityData);

            var robotCardData = System.IO.File.ReadAllText("Data/SeedData/RobotCardSeedData.json");
            var robotCards = JsonSerializer.Deserialize<List<RobotCard>>(robotCardData);

            var pilotCardData = System.IO.File.ReadAllText("Data/SeedData/PilotCardSeedData.json");
            var pilotCards = JsonSerializer.Deserialize<List<PilotCard>>(pilotCardData);

            modelBuilder.Entity<Robot>().HasData(robots);
            modelBuilder.Entity<Pilot>().HasData(pilots);
            modelBuilder.Entity<RobotAbility>().HasData(robotAbilities);
            modelBuilder.Entity<PilotAbility>().HasData(pilotAbilities);
            modelBuilder.Entity<RobotCard>().HasData(robotCards);
            modelBuilder.Entity<PilotCard>().HasData(pilotCards);
        }

    }
}
