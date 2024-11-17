using Bvc.Game.Quest.Services.DbContext;
using Bvc.Game.Quest.Services.Domain;
using Bvc.Game.Quest.Services.Mappers;

namespace Bvc.Game.Quest.Tests.Mappers;

public class DomainMapperTest
{
    [Fact]
    public void Player_Model()
    {
        var achievement = new Achievement { Id = 1, PlayerId = 2 };
        var player = new Player { Id = 2, Achievement = achievement };
        var playerDto = player.ToModel();
        var achievementDto = achievement.ToModel();
        
        Assert.NotNull(playerDto);
        Assert.Equal(playerDto.PlayerName, player.Id);
        Assert.Equal(achievementDto.AchievementName, achievement.Id);
    }
}