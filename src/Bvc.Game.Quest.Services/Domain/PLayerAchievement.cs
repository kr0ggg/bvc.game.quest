namespace Bvc.Game.Quest.Services.Domain;

public class PlayerAchievement : EntityBase
{
    public Player Player { get; set; }
    public Achievement Achievement{ get; set; }
}