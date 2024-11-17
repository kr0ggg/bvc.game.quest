using Bvc.Game.Quest.Services.DbContext;
using Bvc.Game.Quest.Services.Domain;
using Bvc.Game.Quest.Services.Mappers;
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
        var player = new Player { Id = 2 };
        var achievement = new Achievement { Id = 4 };

        dbContext.Setup(x => x.Get<Player>(player.Id)).Returns(player);
        dbContext.Setup(x => x.Get<Achievement>(achievement.Id)).Returns(achievement);
        
        var playerDto = service.PostAchievement(player.Id, achievement.Id);

        Validate.Begin()
            .IsNotNull(playerDto, nameof(playerDto)).Check()
            .GamerEquals(playerDto, player.ToModel())
            .AchievementEquals(playerDto.Achievement, achievement.ToModel())
            .Check();
    }
   

    [Fact]
    public void PostAnotherAchievement()
    {
        //Arrange - create a Player who already has one achievement.
        //Act - call the Api - PostAchievement: same gamerId,  another AchievementId
        //Assert
        //  make sure the "GamerDto" has both achievements
        
        // you will need to use Moq in order to "Setup" the call to the AchievementService.
    }
}