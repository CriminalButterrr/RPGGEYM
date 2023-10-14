class Character
{
    private Random random = new Random();
    
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; private set; }
    public int Defense { get; private set; }
    
    public Character()
    {
       Health = random.Next(20,31);
       Strength = random.Next(5,11);
       Defense = random.Next(0,6); 
    }

    public virtual void Attack(Character target)
    {
        int damage = this.Strength - target.Defense; // Random damage between 10 to 20
        target.Health -= damage;
        Console.WriteLine($"{Name} deals {damage} damage to {target.Name}!");
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void printStats()
    {
        Console.WriteLine($"{this.Name}' Stats");
        Console.WriteLine("------------------------");
        Console.WriteLine($"{this.Name}' Health: {this.Health}");
        Console.WriteLine($"{this.Name}' Strength: {this.Strength}");
        Console.WriteLine($"{this.Name}' Defense: {this.Defense}");
    }
}