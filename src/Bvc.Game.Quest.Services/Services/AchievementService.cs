using Bvc.Game.Quest.Domain;

namespace Bvc.Game.Quest.Services;

public class AchievementService
{
    public Achievement PostAchievement(Player player, int gameId, int achievementId)
    {
        player.Achievement = new Achievement
        {
            PlayerId = player.Id,
            GameId = gameId,
            AchievementId = achievementId
        };
        
        return player.Achievement;
    }
}