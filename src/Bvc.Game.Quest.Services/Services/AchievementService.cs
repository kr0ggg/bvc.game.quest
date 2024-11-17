using Bvc.Game.Quest.Services.DbContext;
using Bvc.Game.Quest.Services.Domain;
using Bvc.Game.Quest.Services.Mappers;
using Bvc.Game.Quest.Services.Models;

namespace Bvc.Game.Quest.Services.Services;

public class AchievementService : IAchievementService
{
    private readonly IDbContext dbContext;

    public AchievementService(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public GamerDto PostAchievement(int playerId, int achievementId)
    {
        var player = dbContext.Get<Player>(playerId);
        var achievement = dbContext.Get<Achievement>(achievementId);
        return player.Add(achievement).ToModel();
    }
}