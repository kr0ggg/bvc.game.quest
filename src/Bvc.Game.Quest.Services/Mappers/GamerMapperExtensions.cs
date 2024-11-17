using Bvc.Game.Quest.Services.Domain;
using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;

namespace Bvc.Game.Quest.Services.Mappers;

public static class GamerMapperExtensions
{
    public static GamerDto ToModel(this Player player)
        => new()
        {
            Id = player.Id,
            Achievement = player.Achievement?.ToModel()
        };

    public static AchievementDto ToModel(this Achievement achievement) =>
        new()
        {
            Id = achievement.Id, 
            GamerId = achievement.PlayerId
        };
}