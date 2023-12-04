using System;
using System.Collections.Generic;

public class Jail
{
    public bool JailRollDice(Player player)
    {
        // Dice dice = new Dice();
        // dice.Roll();
        // if (dice.CheckDoubles()) 
        // {
        //     player.inJail = false; 
        //     player.jailRollCount = 3;
        //     Console.WriteLine("You've rolled doubles to get out of Jail.");
        //     return true;
        // }
        // else
        // {
        //     player.jailRollCount -= 1;
        //     Console.WriteLine("You're still in stuck in jail.");
        //     Console.WriteLine($"You have {player.jailRollCount} rolls left.");
        //     return false;
        // }
        return true;
    }

    public bool JailPay(Player player)
    {
        player.Pay(50);
        player.inJail = false;
        player.jailRollCount = 3;
        Console.WriteLine("You've paid $50 to get out of Jail.");
        return true;
    }

    public bool JailFreeCard(Player player)
    {
        player.inJail = false;
        player.jailRollCount = 3;
        player.out_of_jail_count -= 1;
        Console.WriteLine($"You've used a Get Out of Jail card. You have {player.out_of_jail_count} cards left");       
        return true; 
    }
    
    public bool HandleJail(Player player)
    {
        Console.WriteLine("You are in jail! What would you like to do?");

        bool jailOp1 = true;
        bool jailOp2 = true;
        bool jailOp3 = true;
        string input = "";
    
        while(true)
        {
            if (player.jailRollCount > 0)
            {
                Console.WriteLine($"1. Roll ({player.jailRollCount} tries left)");
            }
            else
            {
                jailOp1 = false;
                Console.WriteLine("1. (Out of rolls)");
            }

            if (player.money >= 50)
            {
                Console.WriteLine($"2. Pay $50");
            }
            else
            {
                jailOp2 = false;
                Console.WriteLine("2. (Not enough money)");
            }

            if (player.out_of_jail_count > 0)
            {
                Console.WriteLine("3. Use a Get Out of Jail card");
            }
            else
            {
                jailOp3 = false;
                Console.WriteLine("3. (Out of GOoJ cards)");
            }
            
            Console.WriteLine($"4. Stay in jail");
            input = Console.ReadLine();

            if ((input == "1" && jailOp1 == false) || (input == "2" && jailOp2 == false) || (input == "3" && jailOp3 == false))
            {
                Console.WriteLine("Invalid input");
            }
            else if (input == "1" || input == "2" || input == "3" || input == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        switch(input)
        {
            case "1":
                bool result = JailRollDice(player);
                return result;
            case "2":
                result = JailPay(player);
                return result;
            case "3":
                result = JailFreeCard(player);
                return result;
            case "4":
                return false;
        }

        return false;
    }
}

// if (currentPlayer.inJail)
// {
    // if (input == "1")
    // {
    //     if (currentPlayer.jailRollCount > 0)
    //     {
    //         dice.Roll();
    //         if (dice.CheckDoubles()) 
    //         {
    //             currentPlayer.inJail = false; 
    //             currentPlayer.jailRollCount = 3;
    //             Console.WriteLine("You've rolled doubles to get out of Jail.");
    //         }
    //         else
    //         {
    //             Console.WriteLine("You're still in stuck in jail.");
    //             currentPlayer.jailRollCount -= 1;
    //             continue;
    //         }
    //     }
    // }
    // else if (input == "2")
    // {
    //     if (currentPlayer.money > 50)
    //     {
    //         currentPlayer.Pay(50);
    //         currentPlayer.inJail = false;
    //         currentPlayer.jailRollCount = 3;
    //         Console.WriteLine("You've paid $50 to get out of Jail.");
    //     }
    //     else
    //     {
    //         Console.WriteLine("You have no money.");
    //     }
    // }
    // else if (input == "3")
    // {
    //     if (currentPlayer.out_of_jail_count > 0)
    //     {
    //         currentPlayer.inJail = false;
    //         currentPlayer.jailRollCount = 3;
    //         currentPlayer.out_of_jail_count -= 1;
    //         Console.WriteLine($"You've used a Get Out of Jail card. You have {currentPlayer.out_of_jail_count} cards left");
    //     }
    //     else
    //     {
    //         Console.WriteLine("You do not have any Get Out of Jail cards");
    //     }
    // }
//     else 
//     {
//         Console.WriteLine("You've chosen to stay in jail.");
//         continue;
//     }
// }