using Bvc.Game.Quest.Services.Domain;
using Bvc.Game.Quest.Services.Models;
using Bvc.Game.Quest.Services.Models.Response;

namespace Bvc.Game.Quest.Services.Mappers;

public static class GamerMapperExtensions
{
    public static GamerDto ToModel(this Player player)
        => new()
        {
            PlayerName = player.Id,
            GamerName = player.Name,
            Achievement = player.Achievements?.Select(a => a.ToModel()).ToList() ?? new List<AchievementDto>()
        };

    public static AchievementDto ToModel(this Achievement achievement) =>
        new()
        {
            AchievementName = achievement.Id,
            AchievementDescription = achievement.Description,
            GamerId = achievement.PlayerId
        };
}