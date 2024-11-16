using System.Collections.Specialized;
using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;
using Bvc.Game.Quest.Services.Services;
using Xerris.DotNet.Core.Validations;

namespace Bvc.Game.Quest.Services.Api;

public class GameQuestFacade
{
    private readonly IAchievementService serviceObject;

    public GameQuestFacade(IAchievementService serviceObject)
    {
        this.serviceObject = serviceObject;
    }

    public AchievementDto PostAchievement(PostAchievementRequest request)
    {
        return serviceObject.PostAchievement(request.GamerId, request.AchievementId);

    }
}