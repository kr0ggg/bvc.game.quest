using Bvc.Game.Quest.Services.Api;
using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;
using Bvc.Game.Quest.Services.Services;
using Moq;
using Xerris.DotNet.Core.Validations;

namespace Bvc.Game.Quest.Tests.Api;

public class GameQuestApiTest : IDisposable
{
    private readonly MockRepository mocks;
    private readonly Mock<IAchievementService> service;
    private readonly GameQuestApi api;
    
    public GameQuestApiTest()
    {
        mocks = new MockRepository(MockBehavior.Strict);
        service = mocks.Create<IAchievementService>();
        api = new GameQuestApi(service.Object);
    }

    public void Dispose() 
        => mocks.VerifyAll();
    
    
    [Fact]
    public void PostAchievement()
    {
        var requestDto = new PostAchievementRequest { GamerId = 1, AchievementId = 1 };
        
        var achievementDto = new AchievementDto
            { Id = requestDto.AchievementId, Name = "HighScore" };
        
        var returnedFromService = new GamerDto { 
            Id = requestDto.GamerId, 
            Name = "Kr0ggg",
            Achievements = [achievementDto]
        };

        service.Setup(x => x.PostAchievement(requestDto.GamerId, requestDto.AchievementId))
               .Returns(returnedFromService);
        
        var response = api.PostAchievement(requestDto);

        Validate.Begin()
            .IsNotNull(response, nameof(response)).Check()
            .IsEqual(response.Id, requestDto.AchievementId, nameof(response.Id))
            .IsNotEmpty(response.Achievements, nameof(response.Achievements))
            .HasExactly(response.Achievements, 1, "has 1 achievement")
            .Contains(response.Achievements, achievementDto, nameof(response.Achievements))
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