public class Enemy
{
    public string Name;
    public int Health;
    public int Damage;
    public string Description;
    private Random random = new Random();
    
    public Enemy(string name, int health, int damage, string description)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Description = description;
        
    }
    
    public int Attack(Character chosenPlayer)
    {
        return random.Next(1,20);
    }
}