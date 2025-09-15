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
            Console.WriteLine("Type the number corresponding to the weapon and the CPU will randomly choose it's weapon. \n1 - Rock, 2 - Paper, 3 - Scissor");

        }
        // koden notere hvor mange gange der gættes forkert 
        private static void printHangman(int wrong)

        {
            if (wrong == 0) // if statement for at notere hver gang der gættes forkert med en illustration 
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("     |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong = 1)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong = 2)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine("  |  |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong = 3)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|  |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong = 4)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|\\|  "); // doubble backslash for at komme ud af den da det er en funktion ellers 
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong = 5)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|\\|  ");
                Console.WriteLine(" /   |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong = 6)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|\\|  ");
                Console.WriteLine(" / \\|  ");
                Console.WriteLine("    ---  ");
            }

        }
        private static int printWord(List<char> guessedLetters, string randomWord) // 2 parametre indført som  er et bogstav vores gættet ord og anden er vores tilfældige ord vi har inddraget. 
        {
            int counter = 0;
            int rightLetters = 0;
            Console.WriteLine();
        }
    }
}
