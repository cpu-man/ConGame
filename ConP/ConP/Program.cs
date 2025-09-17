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
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"WELCOME {name} TO THE CONSOLE");
            //RockPaper(name);
            TicTac(name);
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
                    playerScore++; //Ligger én oven i playerScore
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

        static void TicTac(string name)
        {
            Console.Clear();
            int cpuMove = 0;
            int playerMove = 0;
            bool playAgain = true;
            bool gameOver = false;
            bool validPosition;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome to Tic Tac Toe, {name}");
            Console.WriteLine("Get three X's in a row, after your third input you get to change the position of on of your X's.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            while (playAgain)
            {
            Console.Clear();
            string[,] gameBoard = new string[3, 3];
            for(int row = 0; row<3; row++)
            {
                for(int col =0; col <3; col++)
                {
                    gameBoard[row, col] = ".";
                }
            }


            do
            {
                if (playerMove < 3)
                    {
                        validPosition = true;
                        Console.WriteLine("Which row would you like to place your X on? (1-3)");
                        int rowChoice = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Which coloumn would you like to place your X on? (1-3)");
                        int colChoice = int.Parse(Console.ReadLine()) - 1;

                        if (rowChoice >= 0 && rowChoice < 3 && colChoice >= 0 && colChoice < 3)
                        {
                            gameBoard[rowChoice, colChoice] = "X";
                            playerMove++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid position");
                            validPosition = false;
                        }
                    }
                    PrintBoard(gameBoard);


                if (cpuMove < 3 && !gameOver)
                {
                    Random random = new Random();
                    bool cpuPosition = false;
                    do
                    {
                        int cpuRow = random.Next(0, 3);
                        int cpuCol = random.Next(0, 3);
                        if (gameBoard[cpuRow, cpuCol] == ".")
                        {
                            gameBoard[cpuRow, cpuCol] = "O";
                            cpuPosition = true;
                            cpuMove++;
                            Console.WriteLine($"CPU has placed an O in row {cpuRow + 1}, col {cpuCol + 1}");
                        }
                    } while (!cpuPosition);
                }
                PrintBoard(gameBoard);

             if ((playerMove >= 3 || cpuMove >= 3) && CheckWin(gameBoard, "X") || CheckWin(gameBoard, "O"))
                    {

                    }
            } while (!gameOver && (playerMove < 3 || cpuMove < 3));

        }
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
         
             void CheckWin(string[,] board, string symbol)
            {

            }
    }
}
