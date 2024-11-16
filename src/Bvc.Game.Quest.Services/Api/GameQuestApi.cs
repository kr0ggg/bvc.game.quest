using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;
using Bvc.Game.Quest.Services.Services;

namespace Bvc.Game.Quest.Services.Api;

public class GameQuestApi
{
    private readonly IAchievementService serviceObject;

    public GameQuestApi(IAchievementService serviceObject)
    {
        this.serviceObject = serviceObject;
    }

    public GamerDto PostAchievement(PostAchievementRequest request)
    {
        return serviceObject.PostAchievement(request.GamerId, request.AchievementId);
    }
}