using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;
using Xerris.DotNet.Core.Validations;

namespace Bvc.Game.Quest.Tests.AssertionExtensions;

public static class ValidationExtensions
{
    public static Validation GamerEquals(this Validation v, GamerDto actual, GamerDto expected)
        => v.IsNotNull(actual, nameof(actual)).Check()
            .IsNotNull(expected, nameof(expected)).Check()
            .IsEqual(actual.PlayerName, expected.PlayerName, nameof(actual.PlayerName))
            .AchievementEquals(actual.Achievement, expected.Achievement)
            .Check();

    public static Validation AchievementEquals(this Validation v, AchievementDto actual, AchievementDto expected)
        => v.IsNotNull(actual, nameof(actual)).Check()
            .IsNotNull(expected, nameof(expected)).Check()
            .IsEqual(actual.AchievementName, expected.AchievementName, nameof(actual.AchievementName))
            .IsEqual(actual.GamerId, expected.GamerId, nameof(actual.GamerId))
            .Check();
}