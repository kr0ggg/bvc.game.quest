using Bvc.Game.Quest.Services.Models.Response;

namespace Bvc.Game.Quest.Services.Services;

public class AchievementService : IAchievementService
{
    public AchievementDto PostAchievement(int playerid, int achievementId)
    {
        return new AchievementDto
        {
            Id = achievementId,
            GamerId = playerid
        };
    }
}