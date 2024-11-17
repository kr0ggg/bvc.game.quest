namespace Bvc.Game.Quest.Services.Domain;

public class Achievement : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PlayerId { get; set; }
}