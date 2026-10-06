using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDistanceGame
{
    static internal class Money
    {
        public static int CurrentMoney { get; private set; }

        /// <summary>
        /// Payer un drone
        /// </summary>
        /// <param name="droneCost">Le prix du drone</param>
        /// <returns>Pour indiquer si le drone a été payé</returns>
        public static bool PayDrone(int droneCost)
        {
            if(CurrentMoney >= droneCost)
            {
                CurrentMoney -= droneCost;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Permet de donner de l'argent
        /// </summary>
        /// <param name="moneyAmmount">Le montant d'argent gagner</param>
        /// <returns>Pour indiquer que l'argent a été reçu.</returns>
        public static bool Paycheck(int moneyAmmount)
        {
            CurrentMoney += moneyAmmount;
            return true;
        }

        /// <summary>
        /// écrire l'argent actuel
        /// </summary>
        public static void WriteMoney()
        {
            Console.Write($"Argent : {CurrentMoney}");
        }
    }
}
