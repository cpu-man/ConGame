using Microsoft.CSharp;
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

            {
                string userName;
                byte userAge = 18;
                bool validAge = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to Awesome games");
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
                Console.ResetColor();

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"welcome to world of AwesomeGames {userName}\u001b[0m");

                Console.WriteLine("\nUse UpArrow & DownArrow to chose an option and press the \u001b[32mEnter\u001b[0m key to select");

                ConsoleKeyInfo key;
                int option = 1;
                bool isSelected = false;
                int left = Console.CursorLeft;
                int top = Console.CursorTop; // for at man kun kan vælgem ellem mulighederne
                string color = " \u001b[32m";

                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);

                    Console.WriteLine($"{(option == 1 ? color : "")}Tic Tac Toe \u001b[0m");
                    Console.WriteLine($"{(option == 2 ? color : "")}Hangman \u001b[0m");
                    Console.WriteLine($"{(option == 3 ? color : "")}Rock, Paper, Scissors \u001b[0m");
                    Console.WriteLine($"{(option == 4 ? color : "")}EXIT \u001b[0m");

                    key = Console.ReadKey(true);
                    int choiceInteger = 1;
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            option = (option == 4 ? 1 : option + 1);
                            break;

                        case ConsoleKey.UpArrow:
                            option = (option == 1 ? 4 : option - 1);
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            //choiceInteger = option;
                            break;
                    }
                    if (isSelected)
                    {
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Rock, Paper, Scissors");
                                //RockPaper();
                                break;

                            case 2:
                                Console.WriteLine("HangMan");
                                StartHangman();
                                break;

                            case 3:
                                Console.WriteLine("Tic Tac Toe");
                                //TicTac();
                                break;

                            case 4:
                                Environment.Exit(0);
                                break;
                        }
                    }
                }


                Console.WriteLine($"you have selected the option {option}");
            }
        }




        private static void Hangman(int wrong)
        {
            if (wrong == 0) // if statement for at notere hver gang der gættes forkert med en illustration 
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("     |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine("  |  |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|  |  ");
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|\\ |  "); // doubble backslash for at komme ud af den da det er en funktion ellers 
                Console.WriteLine("     |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|\\ |  ");
                Console.WriteLine(" /   |  ");
                Console.WriteLine("    ---  ");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+ ");
                Console.WriteLine("  O  |  ");
                Console.WriteLine(" /|\\ |  ");
                Console.WriteLine(" / \\ |  ");
                Console.WriteLine("    ---  ");
            }

        }
        private static int printWord(List<char> guessedLetters, string randomWord) // 2 parametre indført som  er et bogstav vores gættet ord og anden er vores tilfældige ord vi har inddraget. 
        {
            int counter = 0; // under disse 3 linjer beskriver vi kort at der er tæller på når vi gætter på bogostaver så de følger med 
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " "); // hvis gættet bogstov er i ordet bliver den medført + mellemrum
                    rightLetters++;
                }
                else
                {
                    Console.Write(" "); // hvis bogstavet ikke er med så kun lav mellemrum 
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(string randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 "); // for at lave linjer under hver bogstav men i anden linje  

            }
        }

        static void StartHangman()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Hangman XOXO");
            Console.WriteLine("----------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "csharp", "zzz", "kuglepen", "sko", "bøger", "datamatiker", "apple", "maserati", "cykelhjelm", "grenaa", "snørebånd", "julefrokost", "sommer", "sol", "fiat" };
            int index = random.Next(wordDictionary.Count);
            string randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 7 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters Guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                // promopt user for input 
                Console.Write("\nguess a letter: ");
                char lettersGuessed = Console.ReadLine()[0];
                // check if letter has allready been guessed / used 
                if (currentLettersGuessed.Contains(lettersGuessed))
                {
                    Console.Write("\r\nThis letter has been guessed.");
                    Hangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    //printLines(randomWord);

                }
                else
                {
                    // check if letter is in the word 
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) if (lettersGuessed == randomWord[i]) { right = true; }
                    {


                        if (right)
                        {
                            Hangman(amountOfTimesWrong);
                            currentLettersGuessed.Add(lettersGuessed);
                            currentLettersRight = printWord(currentLettersGuessed, randomWord);
                            Console.Write("\r\n");
                            //printLines(randomWord);
                        }
                        else
                        {
                            currentLettersGuessed.Add(lettersGuessed);
                            Hangman(amountOfTimesWrong);
                            currentLettersRight = printWord(currentLettersGuessed, randomWord);
                            Console.Write("\r\n");
                            //printLines(randomWord);
                        }
                    }
                    if (right == false)
                    {
                        amountOfTimesWrong++;


                    }
                }
                if (currentLettersRight == lengthOfWordToGuess)
                {
                    Console.WriteLine("\r\n Thank you for your participation get back soon");
                    break;
                }
                if (amountOfTimesWrong == 7)
                {
                    Console.WriteLine("\r\n Thank you for your participation get back soon tomorrow");
                    break;
                }
            }
        }

    }
}