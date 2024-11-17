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
        var requestDto = new PostAchievementRequest { GamerId = 0, AchievementId = 0 };
        var achievementDto = new AchievementDto { Id = requestDto.AchievementId, GamerId = requestDto.GamerId };
        var returnedFromService = new GamerDto { Id = requestDto.GamerId, Achievement = achievementDto};

        service.Setup(x => x.PostAchievement(requestDto.GamerId, requestDto.AchievementId))
               .Returns(returnedFromService);
        
        var response = api.PostAchievement(requestDto);

        Validate.Begin()
            .IsNotNull(response, nameof(response)).Check()
            .IsEqual(response.Id, requestDto.AchievementId, nameof(response.Id))
            .IsEqual(response.Achievement, achievementDto, nameof(response.Achievement))
            .Check();
    }

    [Fact]
    public void PostAnotherAchievement()
    {
        //Arrange - create a Player who already has one achievement.
        //Act - call the Api - PostAchievement: same gamerId,  another AchievementId
        var requestDto = new PostAchievementRequest { GamerId = 0, AchievementId = 0};
        var requestDto1 = new PostAchievementRequest { GamerId = 0, AchievementId = 2 };
        
        var achievementDto = new AchievementDto { Id = requestDto.AchievementId, GamerId = requestDto.GamerId };
        var achievementDto1 = new AchievementDto { Id = requestDto1.AchievementId, GamerId = requestDto1.GamerId };
        var returnedFromService = new GamerDto { Id = requestDto.GamerId, Achievement = achievementDto};

        service.Setup(x => x.PostAchievement(requestDto.GamerId, requestDto.AchievementId))
            .Returns(returnedFromService);
        
        var response = api.PostAchievement(requestDto);
        
        Validate.Begin()
            .IsNotNull(response, nameof(response)).Check()
            .IsEqual(response.Id, requestDto.AchievementId, nameof(response.Id))
            .IsEqual(response.Achievement, achievementDto, nameof(response.Achievement))
            .Check();
        //Assert
        //  make sure the "GamerDto" has both achievements
        
        // you will need to use Moq in order to "Setup" the call to the AchievementService.
    }
}