namespace Bvc.Game.Quest.Services.Domain;

public class Player : EntityBase
{
    public string Name { get; private set; }
    public List<Achievement> Achievements { get; set; } = new List<Achievement>();
}