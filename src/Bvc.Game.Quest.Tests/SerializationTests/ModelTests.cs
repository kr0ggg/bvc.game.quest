using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;
using Xerris.DotNet.Core.Extensions;
using Xerris.DotNet.Core.Utilities;
using Xerris.DotNet.Core.Validations;

namespace Bvc.Game.Quest.Tests.SerializationTests;

public class ModelTests
{
    [Fact]
    public void GamerDto()
        => CanSerialize(() => new GamerDto { Id = 1, Name = "Elvis", Achievements = [] });

    [Fact]
    public void AchievementDto()
        => CanSerialize(() => new AchievementDto { Id = 1, Name = "Elvis" });

    private static void CanSerialize<T>(Func<T> builder) where T : class
    {
        var source = builder();
        var fromJson = source.ToJson().FromJson<T>();
        AssertEquals(source, fromJson);
    }

    private static void AssertEquals<T>(T actual, T expected) where T : class
        => Validate.Begin()
            .IsNotNull(actual, nameof(actual)).Check()
            .IsNotNull(expected, nameof(expected)).Check()
            .IsTrue(actual.ReflectionEquals(expected, true), "equals")
            .Check();
}