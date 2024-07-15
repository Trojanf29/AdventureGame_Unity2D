using System;

[Serializable]
public class Profile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime SavedTime { get; set; }

    public string SelectedHero { get; set; }
    public int CurrentLevel { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Point { get; set; }
    public bool GameOver { get; set; }

    public Profile(string name, string selectedHero, int currentLevel, int maxHealth, int currentHealth, int point)
    {
        Id = Guid.NewGuid();
        Name = name;
        SavedTime = DateTime.UtcNow;

        SelectedHero = selectedHero;
        CurrentLevel = currentLevel;
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        Point = point;
    }
}
