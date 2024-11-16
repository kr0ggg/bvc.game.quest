using Bvc.Game.Quest.Domain;
using Bvc.Game.Quest.Services;

namespace Bvc.Game.Quest.Tests.Services;

public class AchievementServiceTests
{
    private readonly AchievementService service;

    public AchievementServiceTests()
    {
        service = new AchievementService();
    }
    
    [Fact]
    public void PostHighScoreAchievement()
    {
        var player = new Player { Id = 0 };
        var gameId = 0;
        var achievementId = 0;
        
        var achievement = service.PostAchievement(player, gameId, achievementId);

        Assert.Equal(achievement.PlayerId, player.Id);
        Assert.Equal(achievement.AchievementId, achievementId);
        Assert.Equal(achievement.GameId, gameId);
    }

    [Fact]
    public void PlayerHasAchievement()
    {
        var player = new Player();
        var gameId = 0;
        var achievementId = 0;
        
        var achievement = service.PostAchievement(player, gameId, achievementId);
        
        Assert.Equal(achievement.PlayerId, player.Id);
        Assert.Equal(achievement.AchievementId, achievementId);
        Assert.Equal(achievement.GameId, gameId);
        Assert.Equal(achievement, player.Achievement);
    }
}