using System;
using System.Collections.Generic;
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
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"WELCOME {userName} TO THE CONSOLE");
            RockPaper(userName);
            
        }

        static void RockPaper(string name)
        {
            string[] gameObject = { "Rock", "Paper", "Scissors" };
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome to Rock, Paper & Scissors, {name}");
            Console.WriteLine("Type the number corresponding to the weapon and the CPU will randomly choose it's weapon. \n1 - Rock, 2 - Paper, 3 - Scissors. \nPress any key when you're ready.");
            Console.ReadKey();

            //do
            //{
                Random random = new Random();
                int randomObject = random.Next(0, gameObject.Length);
                string cpuChoice = gameObject[randomObject];
                Console.WriteLine("Choose a weapon");
            Console.WriteLine($"CPU chose {cpuChoice}");
            //} while;

        }
    }
}
