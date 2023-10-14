using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Program
{
    static Player playerCharacter;
    static Inventory inventory;
    static Random random = new Random();
    static void Main(string[] args)
    {
        // Initialize stack to manage game states
        Stack<string> gameStateStack = new Stack<string>();
        gameStateStack.Push("MainMenu");

        bool isRunning = true;
        
        while (isRunning)
        {
            // Get the current game state from the stack
            string currentState = gameStateStack.Peek();

            // Main Menu State
            if (currentState == "MainMenu")
            {
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Exit");
                Console.Write("Choose your action: ");

                // Get user input
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Transition to Character Creation State
                    gameStateStack.Push("CharacterCreation");
                }
                else if (choice == "2")
                {
                    // Exit the game
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            // Character Creation State
            else if (currentState == "CharacterCreation")
            {
                Console.Clear();
                Console.WriteLine("=== Character Creation ===");
                Console.Write("Enter character name: ");
                string? playerName = Console.ReadLine();

                if (string.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                }
                else
                {
                    playerCharacter = new Player(playerName);
                }
                
                inventory = new Inventory();
                playerCharacter.printStats();
                Console.ReadKey();

                // Transition to Battle State
                gameStateStack.Pop();
                gameStateStack.Push("Battle");
            }
            // Battle State
            else if (currentState == "Battle")
            {
                Enemy enemy = new Enemy();

                Console.Clear();
                Console.WriteLine("=== Battle State ===");
                Console.WriteLine($"A wild {enemy.Name} appears!");
                while (playerCharacter.IsAlive() && enemy.IsAlive())
                {
                    Console.WriteLine($"{playerCharacter.Name}'s health is {playerCharacter.Health} || {enemy.Name}'s health is {enemy.Health}");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Heal");
                    Console.WriteLine("3. Run");
                    Console.WriteLine("Choose your action:");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1) 
                    {
                    playerCharacter.Attack(enemy);
                    enemy.Attack(playerCharacter);
                    }
                    else if (choice == 2)
                    {
                        playerCharacter.Heal();
                        enemy.Attack(playerCharacter);
                        Console.WriteLine($"You healed yourself. Current Health: {playerCharacter.Health}");
                    }
                    else if (choice == 3)
                    {
                        gameStateStack.Push("MainMenu");
                    }

                    if (!enemy.IsAlive())
                    {
                        Console.WriteLine($"{playerCharacter.Name} has slaine {enemy.Name}");
                        gameStateStack.Push("Looting");
                    }

                    if (!playerCharacter.IsAlive())
                    {
                        Console.WriteLine("You have been slained.");
                        gameStateStack.Push("MainMenu");
                    }
                }
            }
            // Looting State
            else if (currentState == "Looting")
            {
                
                Console.WriteLine("=== Looting State ===");
                if (random.Next(1, 3) == 1)
                {
                    Item item = new Item
                    {
                        Name = "Random Item",
                        StrengthBuff = random.Next(1, 6),
                        DefenseBuff = random.Next(1, 6)
                    };

                    inventory.AddItem(item);
                    Console.WriteLine($"Congratulations! You found a new item: {item.Name}");
                    Console.WriteLine("Do you want to view your inventory? (yes/no)");
                    string? viewInventory = Console.ReadLine().ToLower();

                    if (viewInventory == "yes")
                    {
                        Console.WriteLine("Viewing Invetory...");
                        gameStateStack.Push("viewInventory");
                    }
                    else if (viewInventory == "no")
                    {
                        gameStateStack.Pop();
                    }
                    else 
                    {
                        Console.WriteLine("You have entered an invalid input. Try again");
                    }
                }
            }
            // View Inventory State
            else if (currentState == "viewInventory")
            {
                Console.WriteLine("=== Inventory ===");
                inventory.ViewItems();  
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                gameStateStack.Pop();
                gameStateStack.Pop();
            }

        }
    }
}

