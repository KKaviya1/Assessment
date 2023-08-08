﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerandTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam team = new OneDayTeam();

                while (true)
                {
                    Console.WriteLine("Enter 1: To Add Player, 2: To Remove Player by Id, 3: Get Player By Id, 4: Get Player by Name, 5: Get All Players, 6: Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Player newPlayer = new Player();
                            Console.Write("Enter Player Id: ");
                            newPlayer.PlayerId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Player Name: ");
                            newPlayer.PlayerName = Console.ReadLine();
                            Console.Write("Enter Player Age: ");
                            newPlayer.PlayerAge = int.Parse(Console.ReadLine());
                            team.Add(newPlayer);
                            break;

                        case 2:
                            Console.Write("Enter Player Id to Remove: ");
                            int playerIdToRemove = int.Parse(Console.ReadLine());
                            team.Remove(playerIdToRemove);
                            break;

                        case 3:
                            Console.Write("Enter Player Id to Get: ");
                            int playerIdToGet = int.Parse(Console.ReadLine());
                            Player playerById = team.GetPlayerById(playerIdToGet);
                            if (playerById != null)
                            {
                                Console.WriteLine($"Player Id: {playerById.PlayerId}, Name: {playerById.PlayerName}, Age: {playerById.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine("Player not found.");
                            }
                            break;

                        case 4:
                            Console.Write("Enter Player Name to Get: ");
                            string playerNameToGet = Console.ReadLine();
                            Player playerByName = team.GetPlayerByName(playerNameToGet);
                            if (playerByName != null)
                            {
                                Console.WriteLine($"Player Id: {playerByName.PlayerId}, Name: {playerByName.PlayerName}, Age: {playerByName.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine("Player not found.");
                            }
                            break;

                        case 5:
                            var allPlayers = team.GetAllPlayers();
                            foreach (var player in allPlayers)
                            {
                                Console.WriteLine($"Player Id: {player.PlayerId}, Name: {player.PlayerName}, Age: {player.PlayerAge}");
                            }
                            break;

                        case 6:
                            Console.WriteLine("Exiting program.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                Console.Write("Do you want to continue (yes/no)?: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "yes")
                {
                    Console.WriteLine("Continuing...\n");
                    
                }
                else if (input.ToLower() == "no")
                {
                    Console.WriteLine("Exiting...\n");
                    break;
                   
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }

            }
        }
    }

}
