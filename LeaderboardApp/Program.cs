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
            // Creating a list of players in the tournament
            // to be used for leaderboard rankings.
            // TODO: May want to look at using a Map instead of a list. 
            List<Player> listOfPlayers = new List<Player>();
            
            // int amountOfPlayers;
            
            WelcomeMessage();
            
            int userMenuSelection = int.Parse(ReadLine());
            
            // Here is where the user will make all the interations with the program 
            LeaderboardMenu(listOfPlayers, userMenuSelection);

            // WriteLine("Please enter the number of players for the tournament");


            // try
            // {
            //     amountOfPlayers = int.Parse(ReadLine());
            // }
            // catch (System.FormatException)
            // {
            //     WriteLine("You entered an incorrect value.\nPlease enter a valid number.");
            //     amountOfPlayers = int.Parse(ReadLine());
            // }


            // for (int i = 1; i <= amountOfPlayers; i++)
            // {
            //     WriteLine($"Enter the name of player {i}");
            //     string newPlayerName = ReadLine();
            //     listOfPlayers.Add(new Player { Name = newPlayerName });
            // }

            // RefreshLeaderBoard(listOfPlayers);



            // WriteLine("Would you like to add an additional player?");
            // string tourOrgAnswer = ReadLine();
            // if (tourOrgAnswer == "y")
            // {
            //     InsertNewPlayer(listOfPlayers);
            // }

        }

        // Custom Methods Below
        public static void WelcomeMessage()
        {
            WriteLine("\nWelcome to the custom tournament leaderboard.\n" +
            "Here you will be able to add players and keep a running tally of points.\n");
            
            WriteLine("Please select an option below.\n\n1: Add Player\n" +
            "2: Edit Player\n3: Remove Player\n4: Refresh Leaderboard");

        }


        // Make this return an int
         public static void LeaderboardMenu(List<Player> playerList, int selection)
        {

            switch(selection)
            {
                case 1:
                    WriteLine("Enter the player's name");
                    string addedPlayerName = ReadLine();
                    InsertNewPlayer(playerList, addedPlayerName);
                    break;

                
            }
            WriteLine("Please select an option below.\n\n1: Add Player\n" +
            "2: Edit Player\n3: Remove Player\n4: Refresh Leaderboard");
        }

        public static void InsertNewPlayer(List<Player> playerList, string newPlayerName)
        {
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
