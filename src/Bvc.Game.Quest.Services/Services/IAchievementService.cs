using Bvc.Game.Quest.Services.Models;

namespace Bvc.Game.Quest.Services.Services;

public interface IAchievementService
{
    GamerDto PostAchievement(int playerId, int achievementId);
}