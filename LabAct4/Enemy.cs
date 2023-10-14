using System.Reflection.PortableExecutable;

class Enemy:Character
{
    private Random random = new Random();
    
    public Enemy(): base()
    {
        Name = GenerateRandomName();
    }

    private string GenerateRandomName()
    {
        string[] names = { "Goblin", "Orc", "Troll", "Skeleton", "Dragon", "Witch" };
        return names[random.Next(0, names.Length)];
    }
}