using Bvc.Game.Quest.Services.DbContext;
using Bvc.Game.Quest.Services.Domain;
using Bvc.Game.Quest.Services.Mappers;

namespace Bvc.Game.Quest.Tests.Mappers;

public class DomainMapperTest
{
    [Fact]
    public void Player_Model()
    {
        //Arrange
        var achievement = new Achievement
        {
            Id = 1,
            PlayerId = 2,
        };
        var player = new Player
         {
             Id = 2,
             Achievement = achievement
         };
        
        var playerDto = player.ToModel(player);
        
        
        Assert.NotNull(playerDto);
        Assert.Equal(playerDto.Id, player.Id);
        
        
        
          
          
          

    }




}


// [Fact]
// public void PostAchievement()
// {
//     var requestDto = new PostAchievementRequest { GamerId = 0, AchievementId = 0 };
//     var achievementDto = new AchievementDto { Id = requestDto.AchievementId, GamerId = requestDto.GamerId };
//     var returnedFromService = new GamerDto { Id = requestDto.GamerId, Achievement = achievementDto};
//
//     service.Setup(x => x.PostAchievement(requestDto.GamerId, requestDto.AchievementId))
//         .Returns(returnedFromService);
//         
//     var response = api.PostAchievement(requestDto);
//
//     Validate.Begin()
//         .IsNotNull(response, nameof(response)).Check()
//         .IsEqual(response.Id, requestDto.AchievementId, nameof(response.Id))
//         .IsEqual(response.Achievement, achievementDto, nameof(response.Achievement))
//         .Check();
// }

//




// using Bvc.Game.Quest.Services.Domain;
// using Bvc.Game.Quest.Services.Mappers;
// using Xerris.DotNet.Core.Validations;
//
// namespace Bvc.Game.Quest.Tests.Mappers;
//
// public class GamerMapperExtensionsTests
// {
//     [Fact]
//     public void Player_ToModel()
//     {
//         // Arrange
//         var achievement = new Achievement 
//         { 
//             Id = 1,
//             PlayerId = 2
//         };
//         
//         var player = new Player
//         {
//             Id = 2,
//             Achievement = achievement
//         };
//
//         // Act
//         var result = player.ToModel();
//
//         // Assert
//         Validate.Begin()
//             .IsNotNull(result, nameof(result))
//             .IsEqual(result.Id, player.Id, "Player Id should match")
//             .IsNotNull(result.Achievement, "Achievement should not be null")
//             .IsEqual(result.Achievement.Id, achievement.Id, "Achievement Id should match")
//             .IsEqual(result.Achievement.GamerId, achievement.PlayerId, "GamerId should match PlayerId")
//             .Check();
//     }
//
//     [Fact]
//     public void Achievement_ToModel()
//     {
//         // Arrange
//         var achievement = new Achievement
//         {
//             Id = 1,
//             PlayerId = 2
//         };
//
//         // Act
//         var result = achievement.ToModel();
//
//         // Assert
//         Validate.Begin()
//             .IsNotNull(result, nameof(result))
//             .IsEqual(result.Id, achievement.Id, "Achievement Id should match")
//             .IsEqual(result.GamerId, achievement.PlayerId, "GamerId should match PlayerId")
//             .Check();
//     }
// }