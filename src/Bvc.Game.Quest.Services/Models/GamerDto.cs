using Bvc.Game.Quest.Services.Models.Response;

namespace Bvc.Game.Quest.Services.Models;

public class GamerDto
{
    public int Id { get; set; }
    public List<AchievementDto>? Achievement { get; set; }
}