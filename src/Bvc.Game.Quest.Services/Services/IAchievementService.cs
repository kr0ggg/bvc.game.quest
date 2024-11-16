using Bvc.Game.Quest.Services.Models.Response;

namespace Bvc.Game.Quest.Services.Services;

public interface IAchievementService
{
    AchievementDto PostAchievement(int playerId, int achievementId);
}