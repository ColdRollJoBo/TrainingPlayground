using System;
using System.Collections.Generic;
using LeaderboardLibrary;
using static System.Console;



namespace LeaderboardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfPlayers = 0;

            WriteLine("Please enter the number of players for the tournament");
            try
            {
                amountOfPlayers = int.Parse(ReadLine());

            }
            catch (System.FormatException)
            {
                WriteLine("You entered an incorrect value.\nPlease enter a valid number.");
                amountOfPlayers = int.Parse(ReadLine());

            }

            List<Player> playerNames = new List<Player>();

            for (int i = 1; i <= amountOfPlayers; i++)
            {
                WriteLine($"Enter the name of player {i}");
                string newPlayerName = ReadLine();
                playerNames.Add(new Player { Name = newPlayerName });
            }

            RefreshLeaderBoard(playerNames);

            WriteLine("Would you like to add an additional player?");
            string tourOrgAnswer = ReadLine();
            if (tourOrgAnswer == "y")
            {
                InsertNewPlayer(playerNames);
            }


        }

        public static void InsertNewPlayer(List<Player> playerList)
        {
            WriteLine("Enter the name of the new player enting the tournament ");
            string newPlayerName = ReadLine();
            playerList.Add(new Player { Name = newPlayerName });
            RefreshLeaderBoard(playerList);
        }

        public static void RefreshLeaderBoard(List<Player> playerList)
        {
            WriteLine("\nTournament Player List\n======================");

            foreach (Player p in playerList)
            {
                WriteLine(format: "{0,-17} {1,3:N0}\n----------------------",
                arg0: p.Name,
                arg1: p.points);
            }

        }


    }
}
