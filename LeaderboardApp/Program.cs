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
            // TODO: May want to look at using a dictionary
            List<Player> listOfPlayers = new List<Player>();

            // int amountOfPlayers;

            WelcomeMessage();

            int userMenuSelection = int.Parse(ReadLine());

            // Here is where the user will make all the interations with the program 
            LeaderboardMenu(listOfPlayers, userMenuSelection);



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

            switch (selection)
            {
                case 1:
                    WriteLine("Enter the player's name");
                    string addedPlayerName = ReadLine();
                    InsertNewPlayer(playerList, addedPlayerName);
                    break;
                case 2:
                    EditPlayer(playerList);
                    break;
                case 3:
                    RemovePlayer(playerList);
                    break;
                case 4:
                    RefreshLeaderBoard(playerList);
                    break;


            }
            WriteLine("\n\nSelect from the options below to make any edits.\n\n1: Add Player\t2: Edit Player\t3: Remove Player\n4: Refresh Leaderboard\t 5: Unknown");
            int userMenuSelection = int.Parse(ReadLine());
            LeaderboardMenu(playerList, userMenuSelection);
        }

        public static void InsertNewPlayer(List<Player> playerList, string newPlayerName)
        {
            playerList.Add(new Player { Name = newPlayerName });
            RefreshLeaderBoard(playerList);
        }

        public static void EditPlayer(List<Player> playerList)
        {
            // WriteLine(format: "Choose an option of the edits you'd like to make. {0} or {1}",
            // arg0: "Edit Points",
            // arg1: "Edit Player Name");


            WriteLine("Enter the name of the player you want to edit\n");
            //TODO: Print out all the player names currently in list. May want to use indexes instead for easier access. 

            foreach (Player p in playerList)
            {
                // If we use indexes add a + 1 so a player does not have a zero next to their name
                // but then you will need to -1 when looking in the list becuase of the zero indexing. 
                // WriteLine(playerList.IndexOf(p) + " " + p.Name);
                WriteLine(p.Name);

            }

            try
            {
                string playerToEdit = ReadLine();
                Player foundPlayer = playerList.Find(x => x.Name == playerToEdit);
                if (foundPlayer.Equals(foundPlayer))
                {
                    WriteLine("Enter the number of points to award this player");
                    foundPlayer.points = int.Parse(ReadLine()) + foundPlayer.points;
                }
            }
            catch (SystemException)
            {
                WriteLine("\nThat player is not registered in the tournament.\n");
                EditPlayer(playerList);
            }
        }

        public static void RemovePlayer(List<Player> playerList)
        {
            WriteLine("Enter the name of the player you want to remove\n");
            
            foreach (Player p in playerList)
            {
                WriteLine(p.Name);
            }

             try
            {
                string playerToEdit = ReadLine();
                Player foundPlayer = playerList.Find(x => x.Name == playerToEdit);
                if (foundPlayer.Equals(foundPlayer))
                {
                   playerList.Remove(foundPlayer);
                }
            }
            catch (SystemException)
            {
                WriteLine("\nThat player is not registered in the tournament.\n");
                RemovePlayer(playerList);
            }
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
