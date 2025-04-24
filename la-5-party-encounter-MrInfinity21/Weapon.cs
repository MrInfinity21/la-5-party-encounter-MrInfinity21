public class Weapon
{
    private string _name;
    private int Damage;
    private string _description;

    public Weapon(string name, int damage, string description)
    {
        _name = name;
        Damage = damage;
        _description = description;
    }
    
    Random random = new Random();

    public int Attack()
    {
        return random.Next(1, Damage + 1);
    }
}