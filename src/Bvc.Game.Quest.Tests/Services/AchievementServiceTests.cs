using Bvc.Game.Quest.Domain;
using Bvc.Game.Quest.Services;
using Xerris.DotNet.Core.Validations;

namespace Bvc.Game.Quest.Tests.Services;

public class AchievementServiceTests
{
    private readonly AchievementService service;

    public AchievementServiceTests()
    {
        service = new AchievementService();
    }

    [Fact]
    public void PostAchievement()
    {
        var player = new Player();
        var gameId = 0;
        var achievementId = 0;

        var achievement = service.PostAchievement(player, gameId, achievementId);

        Validate.Begin()
            .IsNotNull(achievement, nameof(Achievement)).Check()
            .IsEqual(player.Achievement, achievement, nameof(player.Achievement))
            .IsEqual(achievement.PlayerId, player.Id, nameof(achievement.PlayerId))
            .IsEqual(achievement.GameId, gameId, nameof(achievement.GameId))
            .Check();
    }

    [Fact]
    public void PostAchievement_MultipleForPlayer()
    {
        //todo
    }
}