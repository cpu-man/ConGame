using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName;
            byte userAge = 18;
            bool validAge = true;
            Console.WriteLine("Please type your name");
            userName = Console.ReadLine();
            do
            {
                Console.WriteLine("Please type your age");
                userAge = Convert.ToByte(Console.ReadLine());
                if (userAge < 18)
                {
                    Console.WriteLine("You're sadly not old enough to use this platform");
                    validAge = false;
                }
                else
                {
                    validAge = true;
                }

            } while (!validAge);
            StartMenu(userName);

        }

        static void StartMenu(string name)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"WELCOME {name} TO THE CONSOLE");
            RockPaper(name);
        }

        static void RockPaper(string name)
        {
            Console.Clear();
            string[] gameObject = { "Rock", "Paper", "Scissors" };
            bool tryAgain = true;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome to Rock, Paper & Scissors, {name}");
            Console.WriteLine("Type the number corresponding to the weapon and the CPU will randomly choose it's weapon. \n1 - Rock, 2 - Paper, 3 - Scissors \nPress any key when you're ready.");
            Console.ReadKey();

            do
            {
                Console.Clear();
                Random random = new Random();
                int randomObject = random.Next(gameObject.Length);
                string cpuChoice = gameObject[randomObject];
                Console.WriteLine("Choose a weapon");
                int userInput = int.Parse(Console.ReadLine());
                string userChoice = gameObject[userInput - 1];
                Console.WriteLine($"{name} chose {userChoice}");
                Console.WriteLine($"CPU chose {cpuChoice}");

                if (userChoice == cpuChoice)
                {
                    Console.WriteLine("It's a draw!");
                }
                else if ((userChoice == gameObject[0] && cpuChoice == gameObject[2]) ||
                        (userChoice == gameObject[1] && cpuChoice == gameObject[0]) ||
                        (userChoice == gameObject[2] && cpuChoice == gameObject[1]))
                {
                    Console.WriteLine($"{name} wins the game!");
                }
                else
                {
                    Console.WriteLine($"CPU wins the game!");
                }
                Console.WriteLine("Want to play again? (y/n)");
                string userResponse = Console.ReadLine().ToLower();
                tryAgain = (userResponse == "y");


            } while (tryAgain);
            StartMenu(name);

        }

       
    }
}
