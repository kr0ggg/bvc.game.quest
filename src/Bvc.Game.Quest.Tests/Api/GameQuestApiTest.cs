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
    private Mock<IAchievementService> service;
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
        var returnedFromService = new AchievementDto { GamerId = requestDto.GamerId, Id = requestDto.GamerId };

        service.Setup(x => x.PostAchievement(requestDto.GamerId, requestDto.AchievementId))
               .Returns(returnedFromService);
        
        var response = api.PostAchievement(requestDto);

        Validate.Begin()
            .IsNotNull(response, nameof(response)).Check()
            .IsEqual(response.Id, requestDto.AchievementId, nameof(response.Id))
            .IsEqual(response.GamerId, requestDto.GamerId, nameof(response.GamerId))
            .Check();
    }
}