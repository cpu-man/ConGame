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
            // Login system til konsollen hvor spilleren kan indsætte sit navn og alder
            string userName;
            byte userAge = 18; // Minimum alder sat til 18
            bool validAge = true;
            Console.WriteLine("Please type your name");
            userName = Console.ReadLine();

            do
            {
                Console.WriteLine("Please type your age");
                userAge = Convert.ToByte(Console.ReadLine()); //Konverterer spillerens input til en Byte og lægger den oveni userAge
                if (userAge < 18)
                {
                    Console.WriteLine("You're sadly not old enough to use this platform");
                    validAge = false;
                }
                else
                {
                    validAge = true; //Hvis spilleren er 18 eller over kører den videre til StartMenu funktionen
                }

            } while (!validAge); // Do while loop kører så længe validAge bool er falsk, hvilket den er så længe spilleren er under 18
            StartMenu(userName); // Kalder på StartMenu funktionen

        }

        static void StartMenu(string name)
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"welcome to world of AwesomeGames, {name}\u001b[0m");

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

                Console.WriteLine($"{(option == 1 ? color : "")}Rock, Paper, Scissors \u001b[0m");
                Console.WriteLine($"{(option == 2 ? color : "")}Hangman \u001b[0m");
                Console.WriteLine($"{(option == 3 ? color : "")}Tic Tac Toe \u001b[0m");
                Console.WriteLine($"{(option == 4 ? color : "")}EXIT \u001b[0m");

                key = Console.ReadKey(true);
                //int choiceInteger = 1;
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
                            RockPaper(name);
                            break;

                        case 2:
                            Console.WriteLine("HangMan");
                            StartHangman(name);
                            break;

                        case 3:
                            Console.WriteLine("Tic Tac Toe");
                            TicTac(name);
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;
                    }
                }
            }


            Console.WriteLine($"you have selected the option: {option}");
        }



        static void RockPaper(string name) //Seperat funktion til sten,saks, papir
        {
            Console.Clear(); //Fjerner det tidligere tekst
            string[] gameObject = { "Rock", "Paper", "Scissors" }; //En string med flere værdier som indeholde spillets muligheder
            bool tryAgain = true;
            int cpuScore = 0;
            int playerScore = 0; //int variable til spillerens og CPU'ens point, starter på 0
            Console.BackgroundColor = ConsoleColor.Magenta; //Skifter farve på konsollens baggrund
            Console.ForegroundColor = ConsoleColor.White; //Skifter farve på konsollens tekst
            Console.WriteLine($"Welcome to Rock, Paper & Scissors, {name}");
            Console.WriteLine("Type the number corresponding to the weapon and the CPU will randomly choose it's weapon. \n1 - Rock, 2 - Paper, 3 - Scissors \nPress any key when you're ready.");
            Console.ReadKey();

            do
            {
                /* Do while loop som kører så længe vores bool er 'true'. 
                 * 'CPU'en vælger et tilfældigt tal fra vores array og trækker én fra så det matcher vores array
                 */
                Console.Clear();
                Random random = new Random();
                int randomObject = random.Next(gameObject.Length);
                string cpuChoice = gameObject[randomObject];
                Console.WriteLine("Choose your weapon");
                int userInput = int.Parse(Console.ReadLine()); //spillerens input bliver konverteret til en int vha. Parse
                string userChoice = gameObject[userInput - 1]; // Ét tal bliver trækket fra spillerens input så det passer til arrays position
                Console.WriteLine($"{name} chose {userChoice}");
                Console.WriteLine($"CPU chose {cpuChoice}");

                if (userChoice == cpuChoice)
                {
                    Console.WriteLine("It's a draw!"); // Hvis spillerens og CPU'ens valg er det samme står det lige
                }
                else if ((userChoice == gameObject[0] && cpuChoice == gameObject[2]) ||
                        (userChoice == gameObject[1] && cpuChoice == gameObject[0]) ||
                        (userChoice == gameObject[2] && cpuChoice == gameObject[1]))
                {
                    Console.WriteLine($"{name} wins the game!"); //Hvis spillerens har valgt det stærkere våben og CPU'en det svagere, vinder spilleren
                    playerScore++; //Ligger én oven i playerScore variablen
                }
                else
                {
                    Console.WriteLine($"CPU wins the game!"); // Alle andre muligheder resulterer i CPU'en vinder
                    cpuScore++; //Ligger én oven i cpuScore
                }

                //string quitKey = Console.ReadLine().ToLower();
                //quitGame = (quitKey == "q");
                Console.WriteLine($"{name} has {playerScore} points \nCPU has {cpuScore} points");
                Console.WriteLine();
                Console.WriteLine("Want to play again? (y/n)");
                string userResponse = Console.ReadLine().ToLower(); //Spillerens svar bliver konverteret til lower case
                tryAgain = (userResponse == "y"); // Hvis spilleren skriver "y" kører loopet, hvis ikke, går den ud


            } while (tryAgain);
            StartMenu(name); //Går tilbage til StartMenu funktionen

        }

        static void TicTac(string name) //MANGLER FLYTTE BRIK EFTER SPIL FUNKTION
        {
            Console.Clear();
            bool tryAgain = true;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"STILL UNDER DEVELOPMENT!!!! \nWelcome to Tic Tac Toe, {name}");
            Console.WriteLine("Get three X's in a row, after your third input you get to change the position of on of your X's.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            do
            {
                int cpuMove = 0;
                int playerMove = 0; // sammen med cpuMove tjekker hvor mange gange der er blevet lagt en brik
                bool gameOver = false; // skifter til sandt når en spiller har vundt
                bool validPosition; //tjekker om spilleren har sat sin brik inden for den 3x3 spillebræt

                Console.Clear();
                //Laver et bræt ud af punktumer i vores arrays
                string[,] gameBoard = new string[3, 3];
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        gameBoard[row, col] = ".";
                    }
                }
            

                do
                {
                    // Hvis spilleren har sat mindre end 3 brikker forsætter loppet
                    if (playerMove < 3)
                    {
                        validPosition = true;
                        Console.WriteLine("Which row would you like to place your X on? (1-3)");
                        int rowChoice = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Which coloumn would you like to place your X on? (1-3)");
                        int colChoice = int.Parse(Console.ReadLine()) - 1; //Konverter spillerens input fra string til int og trækker én fra så det passer til vores Aarray

                        if (rowChoice >= 0 && rowChoice < 3 && colChoice >= 0 && colChoice < 3) //Hvis spillerens input er inden for mængden af arrays vil der sættes X
                        {
                            gameBoard[rowChoice, colChoice] = "X";
                            playerMove++; //Tilføjer én til int playerMove  (0->1->2...)
                        }
                        else
                        {
                            Console.WriteLine("Invalid position");
                            validPosition = false;
                        }
                    }
                    PrintBoard(gameBoard); //Viser brættet med brikker


                    if (cpuMove < 3 && !gameOver)
                    {
                        Random random = new Random();
                        bool cpuPosition = false;
                        do
                        {
                            int cpuRow = random.Next(0, 3);
                            int cpuCol = random.Next(0, 3); //CPU'en vælger tilfældigt tal inden for vores array
                            if (gameBoard[cpuRow, cpuCol] == ".") //Kan kun sætte et brik på punktumerne (frie pladser)
                            {
                                gameBoard[cpuRow, cpuCol] = "O";
                                cpuPosition = true;
                                cpuMove++;
                                Console.WriteLine($"CPU has placed an O in row {cpuRow + 1}, col {cpuCol + 1}");
                            }
                        } while (!cpuPosition);
                    }
                    PrintBoard(gameBoard);

                } while (!gameOver && (playerMove < 3 || cpuMove < 3)); //Kører hele loopet så længe hver spiller har mindre end tre brikker OG gameOver er falsk

                
                //Hvis spilleren ELLER CPU'en lagt 3 brikker OG CheckWin funktionen kan se der er blevet lagt brikker på stribe kører denne if statement
                if ((playerMove >= 3 || cpuMove >= 3) && CheckWin(gameBoard, "X") || CheckWin(gameBoard, "O"))
                {
                    gameOver = true;
                    Console.WriteLine(CheckWin(gameBoard, "X") ? $"{name} won!" : "CPU won!");
                    //Hvis CheckWin funktionen svarer tilbage med 'true' kører den, den første sætning. Hvis den svarer 'false' kører den sætningen efter kolon
                }
                else
                {
                    gameOver = false;
                    Console.WriteLine("Nobody won...");
                }
                Console.WriteLine("Do you want to try again? (y/n)");
                string userResponse = Console.ReadLine().ToLower(); //Spillerens svar bliver konverteret til lower case
                tryAgain = (userResponse == "y"); // Hvis spilleren skriver "y" kører loopet, hvis ikke, går den ud. Virker dog ikke ordenligt
            } while (tryAgain);
            StartMenu(name);


            //Laver en ny udgave af brættet hver gang der laves ændringer på den og 'printes' ud
            void PrintBoard(string[,] board)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write(board[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
            
            //Tjekker om kryds eller bolle er blevet sat på stribe når der er blevet lagt tre brikker fra hver
            bool CheckWin(string[,] board, string symbol)
            {
                for (int row = 0; row < 3; row++)
                {
                    //Tjekker hver række og symbol (sat til X og O i CheckWin variablen l. 256)
                    if (board[row, 0] == symbol && board[row, 1] == symbol && board[row, 2] == symbol)
                        return true;
                }
                for (int col = 0; col < 3; col++)
                {
                    if (board[col, 0] == symbol && board[col, 1] == symbol && board[col, 2] == symbol)
                        return true;
                }
                return false; //Hvis X ikke er på stribe, så betyder det at CPU'en har vundet og returner falsk
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

        static void StartHangman(string name)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to Hangman {name}");
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
