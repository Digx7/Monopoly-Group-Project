using System;
using System.Collections.Generic;

public class Special : Tile
{
    Random random = new Random();
    public Special(string name)
    {
        this.name = name;
    }

    public void PassGo(Player player)
    {
        player.money += 200;
    }

    public void GoToJail(Player player)
    {
        player.location = 10; // How to set a player's location
        player.inJail = true;
    }

    // public void Update(Player player)   // Land on Update tile -> pay 200
    // {
    //     Console.WriteLine("Your PC rebooted for an update. Pay $200");  // How to display message
    //     player.Pay(200);
    // }

    public void Crash(Player player)   // Land on Crash tile -> pay 200
    {
        Console.WriteLine("Your PC crashed. Pay $75");
        player.Pay(75);
    }

    public void DrawChanceCard(Board board, Player player, List<Player> playerList)
    {
        // Console.WriteLine("ERROR: Draw a card!");
        // chanceType currentCard = board.chanceCard[random.Next(0, 16)];
        // Console.WriteLine(currentCard.getDescription());
        // int previousLocation = 0;

        // switch(currentCard.getID())
        // {
        //     case 1: case 2: case 3: case 7:
        //         if (player.location > currentCard.getSetLocation())
        //         {
        //             Console.WriteLine("You passed Go! and got $200!");
        //             player.money += 200;
        //             Console.WriteLine($"New balance: ${player.money}");
        //             Console.WriteLine();
        //         }

        //         player.location = currentCard.getSetLocation();
        //         break;
                
        //     case 4:
        //         previousLocation = player.location;
        //         if (player.location > 28 || player.location <= 12)
        //         {
        //             Console.WriteLine("You've advanced to Surfshark");
        //             player.location = 12; // Advance to Surfshark if between certain tiles
        //         }
        //         else if (player.location > 12 || player.location <= 28)
        //         {
        //             Console.WriteLine("You've advanced to NordVPN");
        //             player.location = 28; // Advance to NordVPN if between certain tiles
        //         }
        //         if (player.location < previousLocation) 
        //         {
        //             Console.WriteLine("You passed Go! Have $200!");
        //             player.money += 200;
        //             Console.WriteLine($"New balance: ${player.money}");
        //             Console.WriteLine();
        //         }
        //         player.meAgain = true;
        //         break;
                
        //     case 5: case 6:
        //         previousLocation = player.location;
        //         if (player.location < 5 || player.location >= 35)
        //         {
        //             Console.WriteLine("You've advanced to CPP");
        //             player.location = 5; // Advance to CPP if player location is before it
        //         }
        //         else if (5 <= player.location && player.location < 15)
        //         {
        //             Console.WriteLine("You've advanced to Java");
        //             player.location = 15;
        //         }
        //         else if (15 <= player.location && player.location < 25)
        //         {
        //             Console.WriteLine("You've advanced to HTML");
        //             player.location = 25;
        //         }
        //         else if (25 <= player.location && player.location < 35)
        //         {
        //             Console.WriteLine("You've advanced to Python");
        //             player.location = 35;
        //         }
        //         if (player.location < previousLocation) 
        //         {
        //             Console.WriteLine("You passed Go! Have $200!");
        //             player.money += 200;
        //             Console.WriteLine($"New balance: ${player.money}");
        //             Console.WriteLine();
        //         }
        //         player.meAgain = true;
        //         break;

        //     case 8:
        //         player.location -= 3;   // TODO: Make it so that moving the player back 3 tiles executes whatever that tile is
        //         break;
                
        //     case 9:
        //         player.inJail = true;
        //         player.location = 10;
        //         break;
            
        //     case 10:
        //         player.out_of_jail_count += 1;
        //         break;

        //     case 11: case 12:
        //         player.money += currentCard.getModCash();
        //         break;

        //     case 13:
        //         foreach (Player p in playerList)
        //         {
        //             if (player != p)
        //             {
        //                 player.Pay(50);
        //                 p.money += 50;
        //                 Console.WriteLine($"You paid $50 to {p.name}.");
        //             }
        //         }
        //         break;

        //     case 14:
        //         player.money -= currentCard.getModCash();
        //         break;

        //     case 15:
        //         int owed = 0;
        //         foreach ((string color, List<Property> properties) in player.propertyDict)
        //         {
        //             if (player.monopolies[color])
        //             {
        //                 foreach (Property property in properties)
        //                 {
        //                     if (property.numHouses == 5) owed += 100;
        //                     else owed += 25 * property.numHouses;
        //                 }
        //             }
        //         }
        //         break;
        // }
    }

    public void DrawCommCard(Board board, Player player, List<Player> playerList)
    {
        // Console.WriteLine("Warning: Draw a card!");
        // commType currentCard = board.commCard[random.Next(0, 16)];
        // Console.WriteLine(currentCard.getDescription());

        // switch(currentCard.getID())
        // {
        //     case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
        //         player.money += currentCard.getModCash();
        //         break;

        //     case 8:
        //         foreach (Player p in playerList)
        //         {
        //             if (player != p)
        //             {
        //                 p.money -= 10;
        //                 player.money += 1;
        //                 Console.WriteLine($"You collected $10 from {p.name}.");
        //             }
        //         }
        //         break;

        //     case 9: case 10:
        //         player.location = currentCard.getSetLocation();
        //         break;

        //     case 11:
        //         player.out_of_jail_count += 1;
        //         break;

        //     case 12: case 13: case 14:
        //         player.Pay(currentCard.getModCash());
        //         break;
                
        //     case 15:
        //         int owed = 0;
        //         foreach ((string color, List<Property> properties) in player.propertyDict)
        //         {
        //             if (player.monopolies[color])
        //             {
        //                 foreach (Property property in properties)
        //                 {
        //                     if (property.numHouses == 5) owed += 115;
        //                     else owed += 40 * property.numHouses;
        //                 }
        //             }
        //         }
        //         break;
        // }
    }

}