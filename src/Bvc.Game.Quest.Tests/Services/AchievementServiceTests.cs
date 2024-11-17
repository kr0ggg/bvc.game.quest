using Bvc.Game.Quest.Services.DbContext;
using Bvc.Game.Quest.Services.Domain;
using Bvc.Game.Quest.Services.Mappers;
using Bvc.Game.Quest.Services.Models.Response;
using Bvc.Game.Quest.Services.Services;
using Bvc.Game.Quest.Tests.AssertionExtensions;
using Moq;
using Xerris.DotNet.Core.Validations;

namespace Bvc.Game.Quest.Tests.Services;

public class AchievementServiceTests : IDisposable
{
    private readonly MockRepository mocks;
    private readonly Mock<IDbContext> dbContext;
    private readonly AchievementService service;

    public AchievementServiceTests()
    {
        mocks = new MockRepository(MockBehavior.Strict);
        dbContext = mocks.Create<IDbContext>();
        service = new AchievementService(dbContext.Object);
    }

    public void Dispose() => mocks.VerifyAll();

    [Fact]
    public void PostAchievement()
    {
        var achievement = new Achievement { Id = 4 };
        var expected = new AchievementDto { Id = 1, Name = achievement.Name };
        var player = new Player { Id = 2};

        dbContext.Setup(x => x.Get<Player>(player.Id)).Returns(player);
        dbContext.Setup(x => x.Get<Achievement>(achievement.Id)).Returns(achievement);
        
        var playerDto = service.PostAchievement(player.Id, achievement.Id);

        Assert.NotNull(playerDto);
        Assert.Equal(player.Id, playerDto.Id);
        Assert.Equal(player.Name, playerDto.Name);
        Assert.NotEmpty(playerDto.Achievements);
        Assert.Equal(1, playerDto.Achievements.Count);

        var actual = playerDto.Achievements.First();
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Name, actual.Name);
    }

    [Fact]
    public void PostAnotherAchievement()
    {
        var highScore = new Achievement { Id = 4 , Name = "HighScore"};
        var player = new Player { Id = 2 , Name = "Elvis"};
        player.Add(highScore);
        
        var personalBest = new Achievement { Id = 2 , Name = "Personal Best"};

        dbContext.Setup(x => x.Get<Player>(player.Id)).Returns(player);
        dbContext.Setup(x => x.Get<Achievement>(personalBest.Id)).Returns(personalBest);

        var playerDto = service.PostAchievement(player.Id, personalBest.Id);
        
        Assert.NotNull(playerDto);
        Assert.Equal(player.Id, playerDto.Id);
        Assert.Equal(player.Name, playerDto.Name);
        
        Assert.NotEmpty(playerDto.Achievements);
        Assert.Equal(2, playerDto.Achievements.Count);

        var actualHighScore = playerDto.Achievements.First();
        Assert.Equal(actualHighScore.Id, 1);
        Assert.Equal(actualHighScore.Name, highScore.Name);
        
        var actualPb = playerDto.Achievements.Last();
        Assert.Equal(actualPb.Id, 2);
        Assert.Equal(actualPb.Name, personalBest.Name);
    }
}