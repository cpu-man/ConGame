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
            
        }

        static void RockPaper(string name)
        {
            string[] gameObject = { "Rock", "Paper", "Scissor" };
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome to Rock, Paper & Scissors, {name}");
            Console.WriteLine("");
        }
    }
}
