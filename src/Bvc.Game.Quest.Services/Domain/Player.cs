namespace Bvc.Game.Quest.Services.Domain;

public class Player : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public List<PlayerAchievement> Achievements { get; set; } = [];

    public Player Add(Achievement achievement)
    {
        Achievements.Add(new PlayerAchievement
        {
            Id = Achievements.Count + 1,
            Player = this,
            Achievement = achievement
        });
        return this;
    }
}