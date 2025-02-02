using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;
using Xerris.DotNet.Core.Validations;

namespace Bvc.Game.Quest.Tests.AssertionExtensions;

public static class ValidationExtensions
{
    public static Validation GamerEquals(this Validation v, GamerDto actual, GamerDto expected)
        => v.IsNotNull(actual, nameof(actual)).Check()
            .IsNotNull(expected, nameof(expected)).Check()
            .IsEqual(actual.Id, expected.Id, nameof(actual.Id))
            .Check();

    public static Validation AchievementEquals(this Validation v, AchievementDto actual, AchievementDto expected)
        => v.IsNotNull(actual, nameof(actual)).Check()
            .IsNotNull(expected, nameof(expected)).Check()
            .IsEqual(actual.Id, expected.Id, nameof(actual.Id))
            .IsEqual(actual.Id, expected.Id, nameof(actual.Id))
            .IsEqual(actual.Name, expected.Name, nameof(actual.Name))
            .Check();
}