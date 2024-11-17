namespace Bvc.Game.Quest.Services.Domain;

public class Player : EntityBase
{
    public Player()
     => Achievements = new List<PlayerAchievement>();
    
    public string Name { get; set; }
    public List<PlayerAchievement> Achievements { get; set; }

    public void Add(Achievement achievement)
    {
        Achievements.Add(new PlayerAchievement
        {
            Id = this.Achievements.Count + 1,
            Player = this,
            Achievement = achievement
        });
    }
}