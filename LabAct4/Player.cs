using System.Linq.Expressions;
using System.Transactions;

class Player:Character
{
    private bool canUseHeal = true;
    
    public Player(string name): base()
    {
        Name = name;
    }

    public void Heal()
    {
        if (canUseHeal)
        {
            int healAmount = (int)(0.2 * Health);
            Health += healAmount;
            canUseHeal = false;
        }
        else
        {
            Console.WriteLine("You can't use heal right now. Wait for your next turn.");
        }
    } 
}
