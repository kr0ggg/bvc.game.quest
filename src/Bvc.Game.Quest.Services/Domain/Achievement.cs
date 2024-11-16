namespace Bvc.Game.Quest.Services.Domain;

public class Achievement : EntityBase
{
    public int PlayerId { get; set; }
    public int GameId { get; set; }
}