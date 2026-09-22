using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneDistanceGame
{
    internal static class Interface
    {
        
        //Variables tableaux
        private static string[] menuHome = { "Play", "Help", "Options", "Quit"};

        //Variables standards
        private static int menuSelected = 0;
        private static int maxCursorDown = menuHome.Length;
        private static int instructionOffsetTop = maxCursorDown + 2;
        private static int menuLeftOffset = 5;
        public static bool ContinuePlaying { get;  private set; } = true;
        public static bool IsPlaying { get; private set; } = false;


        /// <summary>
        /// Permet d'afficher l'interface du Menu
        /// </summary>
        public static void DisplayMenu()
        {
            for (int i = 0; i < menuHome.Length; i++)
            {
                Console.SetCursorPosition(menuLeftOffset, i);
                Console.WriteLine(menuHome[i]);

                if (i == menuHome.Length - 1)
                {
                    Console.SetCursorPosition(menuLeftOffset, 0);
                }

                if (i == 0)
                {
                    DisplayNavigation();
                }
            }
        }


        /// <summary>
        /// Permet de gérer les touches presser par le joueur.
        /// </summary>
        public static void UserInputHandler()
        {
            ConsoleKey userInput = Console.ReadKey(true).Key;

            switch (userInput)
            {
                //Descendre
                case ConsoleKey.DownArrow:
                    menuSelected = MoveCursor(menuSelected, false);
                    break;
                //Monter
                case ConsoleKey.UpArrow:
                    menuSelected = MoveCursor(menuSelected, true);
                    break;
                //Sélectionner/Entrer
                case ConsoleKey.Enter:
                    MenuSelectedHandler(menuSelected);
                    break;
            }
        }


        /// <summary>
        /// Permet d'écrire les instructions pour naviguer à travers le menu.
        /// </summary>
        private static void DisplayNavigation()
        {
            Console.SetCursorPosition(0, instructionOffsetTop);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Navigation");
            WriteInstruction("Monter:UpArrow", ConsoleColor.Green, ':');
            WriteInstruction("Descendre:DownArrow", ConsoleColor.Green, ':');
            WriteInstruction("Selectionner:Enter", ConsoleColor.Green, ':');
            Console.ForegroundColor = ConsoleColor.White;
        }


        /// <summary>
        /// Permet d'écrire la navigation en blanc avec l'instruction en couleur
        /// </summary>
        /// <param name="instruction">L'instruction qu'on veut donner. Ex: "up:UpArrow"</param>
        /// <param name="colorInput">La couleur qu'on veut donner à l'instruction</param>
        private static void WriteInstruction(string instruction, ConsoleColor colorInput, char charToCheck)
        {
            int wordPlaceNumber = 0;
            string[] splittedInstruction = instruction.Split(charToCheck);

            foreach (string line in splittedInstruction)
            {
                wordPlaceNumber++;
                if (wordPlaceNumber == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{line}:");
                }
                else if (wordPlaceNumber == 2)
                {
                    Console.ForegroundColor = colorInput;
                    Console.WriteLine($"{line}");
                }
            }

        }


        /// <summary>
        /// Permet de bouger le curseur dans le menu.
        /// </summary>
        /// <param name="menuPos">Permet de savoir la position du curseur pour éviter de sortir du menu</param>
        /// <param name="isUp">Permet de savoir si l'utilisateur veut monter ou descendre le curseur</param>
        /// <returns>Retourne la nouvelle position/option que l'utilisateur survole dans le menu</returns>
        private static int MoveCursor(int menuPos, bool isUp)
        {
            if (isUp)
            {
                if (menuPos > 0)
                {
                    menuPos -= 1;
                    Console.SetCursorPosition(menuLeftOffset - 2, menuPos + 1);
                    Console.Write($"  {menuHome[menuPos + 1]}");
                }
            }
            else
            {
                if (menuPos < maxCursorDown - 1)
                {
                    menuPos += 1;
                    Console.SetCursorPosition(menuLeftOffset - 2, menuPos - 1);
                    Console.Write($"  {menuHome[menuPos - 1]}");
                }
            }
            Console.CursorTop = menuPos;
            Console.CursorLeft = menuLeftOffset - 2;
            Console.Write($"->{menuHome[menuPos]}");


            return menuPos;
        }


        /// <summary>
        /// Va demander à l'utilisateur s'il est sûr de vouloir quitter le programme
        /// </summary>
        private static void AskSure()
        {
            
            Console.Clear();
            Console.WriteLine("Êtes-vous sûr?");
            Console.WriteLine("Oui(Y)");
            Console.WriteLine("Non(N)");
            Console.Write("Entrer votre choix: ");
            string playerChoice = Console.ReadLine();
            CheckPlayerChoice(playerChoice);
        }


        /// <summary>
        /// Va vérifier le choix du joueur
        /// </summary>
        /// <param name="plrChoice">Le choix entrer par le joueur</param>
        private static void CheckPlayerChoice(string plrChoice)
        {
            if (plrChoice == "Y" || plrChoice == "y")
            {
                ContinuePlaying = false;
            }
            else if(plrChoice == "N" || plrChoice == "n")
            {
                Console.Clear();
                DisplayMenu();
            }
            else
            {
                Console.WriteLine("Entrer invalide");
                Thread.Sleep(500);
                AskSure();
            }
        }

        /// <summary>
        /// Permet de gérer quelle option l'utilisateur a sélectionné.
        /// </summary>
        /// <param name="menuOptionSelected">Permet de savoir quelle option est choisi dans le menu</param>
        private static void MenuSelectedHandler(int menuOptionSelected)
        {
            switch (menuOptionSelected)
            {
                //Le bouton "Play"
                case 0:
                    Console.Clear();
                    IsPlaying = true;
                    break;
                //Le bouton "Help"
                case 1:
                    Console.Clear();
                    Console.WriteLine("Help Pressed!");
                    break;
                //Le bouton "Option"
                case 2:
                    Console.Clear();
                    Console.WriteLine("Option Pressed!");
                    break;
                //Le bouton "Quitter"
                case 3:
                    AskSure();
                    break;
            }
        }

    }
}