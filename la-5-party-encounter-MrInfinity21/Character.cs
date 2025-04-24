public class Character
{
    public Weapon _weapon;
    public int Health;
    public string Name;
    public string Description;
    private Random random = new Random();

    public Character(int health, string name, Weapon weapon, string description)
    {
        
        Health = health;
        Name = name;
        _weapon = weapon;
        Description = description;

    }
    
  
    public int Attack(Enemy enemy)
    {
        return random.Next(1,20);
    }
}