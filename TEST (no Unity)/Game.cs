using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Console.WriteLine("How many players: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int playerCount)) Console.WriteLine($"{playerCount} players"); 
        else Console.WriteLine("Invalid input.");

        // game loop's starting variables
        Random random = new Random();
        List<Player> playerList = new List<Player>();
        for (int i = 0; i < playerCount; i++) playerList.Add(new Player());
        Dice dice = new Dice();
        int currentPlayerIndex = random.Next(0, playerCount);  // non-inclusive
        Player currentPlayer;
        int rolledDoublesCount = 0;
        bool play = true;

        while (play)
        {
            Console.WriteLine($"Player Count: {playerList.Count}");  // just for testing
            
            Console.WriteLine("Start of a turn");
            currentPlayer = playerList[currentPlayerIndex];  // currentPlayer is set to the respective player
            dice.Roll();  // player rolls dice
            currentPlayer.ModifyLocation(dice.GetTotal());  // player moves according to dice roll
            

            // handles player rolling doubles
            if (dice.CheckDoubles())  // if player rolls doubles
            {
                if (rolledDoublesCount == 2)  // handles player rolling doubles for the 3rd time
                {
                    ;  // go to jail
                    if (currentPlayerIndex == playerCount - 1) currentPlayerIndex = 0;
                    else currentPlayerIndex++;
                    rolledDoublesCount = 0;
                }
                else rolledDoublesCount++;
            }
            else if (!dice.CheckDoubles())  // if player doesn't roll doubles
            {
                if (currentPlayerIndex == playerCount - 1) currentPlayerIndex = 0;
                else currentPlayerIndex++;
                rolledDoublesCount = 0;
            }

            if (playerList.Count > 1) playerList.RemoveAt(playerList.Count - 1);  // just for testing

            // when there's one person left, the loop ends
            if (playerList.Count == 1) 
            {
                Console.WriteLine("Someone won!");
                play = false;
            }
        }
        Console.WriteLine("End of main.");
    }
}