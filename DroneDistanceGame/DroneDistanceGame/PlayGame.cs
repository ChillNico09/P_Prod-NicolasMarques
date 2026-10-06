using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneDistanceGame
{
    internal static class PlayGame
    {
        //Variables
        private static List<Drone> listDrones = Interface.ListDrones;
        private static bool continuePlaying = Interface.ContinuePlaying;
        private static bool isPlaying = Interface.IsPlaying;
        private static bool isChoosing = Interface.IsChoosing;
        private static int droneIndex = Interface.DroneIndex;

        /// <summary>
        /// Va appeler les autres méthodes pour le bon déroulement du jeu
        /// </summary>
        public static void StartGame()
        {
            Interface.DisplayMenu();
            SetConsoleParam();
            Interface.CreateListElement();
            ContinuePlayingLoop();
        }

        /// <summary>
        /// Va afficher l'interface puis commencer une boucle
        /// </summary>
        private static void ContinuePlayingLoop()
        {
            while (continuePlaying)
            {
                IsChoosingCondition();
                Interface.UserInputHandler();
                UpdateVar();
            }
        }

        /// <summary>
        /// Une condition pour savoir si l'utilisateur est en train de choisir un drone
        /// </summary>
        private static void IsChoosingCondition()
        {
            if (isChoosing)
            {
                Interface.ChooseDrone();
                UpdateVar();
                IsPlayingLoop();
            }
        }

        /// <summary>
        /// Une boucle permettant au drone d'avancer
        /// </summary>
        private static void IsPlayingLoop()
        {
            while (isPlaying)
            { 
                listDrones[droneIndex].MoveDrone();
                //Interface.ChooseDrone(listDrones);
                Thread.Sleep(100);
                UpdateVar();
            }
        }

        /// <summary>
        /// Met les paramètres de la console
        /// </summary>
        private static void SetConsoleParam()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Va mettre à jour les variables provennant d'autre classe
        /// </summary>
        private static void UpdateVar()
        {
            continuePlaying = Interface.ContinuePlaying;
            isPlaying = Interface.IsPlaying;
            isChoosing = Interface.IsChoosing;
            droneIndex = Interface.DroneIndex;
        }

    }
}
