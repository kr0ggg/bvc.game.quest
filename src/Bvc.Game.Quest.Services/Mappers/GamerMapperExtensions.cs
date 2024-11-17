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
            Name = player.Name,
            Achievements = player.Achievements.ToModels()
        };

    public static List<AchievementDto> ToModels(this IEnumerable<PlayerAchievement> achievements)
        => achievements.Select(x => x.ToModel()).ToList();
    
    public static AchievementDto ToModel(this PlayerAchievement subject) =>
        new()
        {
            Id = subject.Id,
            Name = subject.Achievement.Name
        };
}