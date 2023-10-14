class Inventory
{
    private List<Item> items = new List<Item>();

    public Inventory AddItem(Item item)
    {
        items.Add(item);
        return this;
    }

    public void UseItem(Item item)
    {
        items.Remove(item);
    }

    public void ViewItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"Item: {item.Name}, Strength Buff: {item.StrengthBuff}, Defense Buff: {item.DefenseBuff}");
        }
    }
}