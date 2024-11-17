using Bvc.Game.Quest.Services.Models.Response;
using Bvc.Game.Quest.Services.Domain;

namespace Bvc.Game.Quest.Services.Models;

public class GamerDto
{
    
    public int PlayerName { get; set; }
    public string GamerName { get; set; }
    public List<AchievementDto> Achievement { get; set; } = new List<AchievementDto>();
}