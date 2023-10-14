using System.Linq.Expressions;
using System.Transactions;

class Player:Character
{
    private bool canUseHeal = true;
    
    public Player(string name): base()
    {
        Name = name;
    }

    public override void Attack(Character target)
    {
        base.Attack(target);
        if (!canUseHeal)
        {
            canUseHeal = true;
        }
    }
    public void Heal()
    {
        if (canUseHeal)
        {
            int healAmount = (int)(0.2 * Health);
            Console.WriteLine($"You have healed for {healAmount} health points.");
            this.Health += healAmount;
            canUseHeal = false;
        }
        else
        {
            Console.WriteLine("Heal is on cooldown! Wait for the next turn.");
            canUseHeal = true;
        }
    } 
}
