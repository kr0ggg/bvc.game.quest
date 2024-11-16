using Bvc.Game.Quest.Services.Services;
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
        var playerid = 0;
        var achievementId = 0;

        var achievement = service.PostAchievement(playerid, achievementId);

        Validate.Begin()
            .IsNotNull(achievement, nameof(achievement)).Check()
            .IsEqual(achievement.GamerId, playerid, nameof(achievement.GamerId))
            .IsEqual(achievement.Id, achievementId, nameof(achievement.Id))
            .Check();
    }

    [Fact(Skip = "student to build")]
    public void PostAchievement_MultipleForPlayer()
    {
        throw new NotImplementedException();
    }
}