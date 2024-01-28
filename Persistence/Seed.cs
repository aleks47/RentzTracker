using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Games.Any()) return;

            var activities = new List<Game>
            {
                new Game
                {
                    Description = "Game 1",
                    CreationDate = DateTime.UtcNow.AddMonths(-2)
                },
                new Game
                {
                    Description = "Game 2",
                    CreationDate = DateTime.UtcNow.AddMonths(-1)
                },
                new Game
                {
                    Description = "Game 3",
                    CreationDate = DateTime.UtcNow.AddMonths(1)
                },
            };

            await context.Games.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}