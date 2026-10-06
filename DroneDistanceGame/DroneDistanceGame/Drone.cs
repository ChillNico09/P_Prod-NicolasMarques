using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneDistanceGame
{
    internal class Drone
    {
        //Variables
        private const string SPRITEALIVE = "x-0-x";
        private const string SPRITEDEAD = "|-x-|";

        private bool isDead;
        private int posTop;
        private int posLeft;
        private bool isInShop;
        private int moneyAward = 1;

        private int _totalBattery;
        private float _currentBattery;
        private float _batteryUsage;

        //Attributs
        public int TotalBattery
        {
            get
            {
                return _totalBattery;
            }

            private set
            {
                if (value > 0 && value <= 1000)
                {
                    _totalBattery = value;
                }
                else
                {
                    _totalBattery = 0;
                }
            }
        }

        public float CurrentBattery
        {
            get
            {
                return _currentBattery;
            }

            private set
            {
                if(value > 0 && value <= _totalBattery)
                {
                    _currentBattery = value;
                }
                else
                {
                    _currentBattery = 0;
                }
            }
        }

        public float BatteryUsage
        {
            get
            {
                return _batteryUsage;
            }

            private set
            {
                if(value > 0 && value <= _totalBattery / 10)
                {
                    _batteryUsage = value;
                }
                else
                {
                    _batteryUsage = _totalBattery / 10;
                }
            }
        }

        public string DroneName { get; private set; }
        public bool isUnlocked { get; private set; } = false;
        public int DroneCost { get; private set; }

        public Drone(int totalBattery, float currentBattery, float batteryUsage, string droneName, int droneCost)
        {
            this.TotalBattery = totalBattery;
            this.CurrentBattery = currentBattery;
            this.BatteryUsage = batteryUsage;
            this.DroneCost = droneCost;

            isDead = false;
            posLeft = 0;
            posTop = 0;
            DroneName = droneName;
            isInShop = true;
            
        }


        /// <summary>
        /// Va permettre au drone de bouger.
        /// Méthode qui appelle plein d'autre méthode.
        /// </summary>
        public void MoveDrone()
        {
            bool beenPaid = false;
            EraseSprite();
            DisplayDrone(isDead);
            if (!isDead)
            {
                ChangeDroneValue();
                DisplayStats(true);
                moneyAward = posLeft;
            }
            else
            {
                beenPaid = Money.Paycheck(moneyAward);
                if (beenPaid)
                {
                    BackToMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Petit tricheur!");
                }
            }
        }

        /// <summary>
        /// Retourner au menu et reset les stats du drone
        /// </summary>
        private void BackToMenu()
        {
            CurrentBattery = TotalBattery;
            isInShop = true;
            isDead = false;
            posLeft = 0;
            posTop = 0;
            moneyAward = 0;
        }

        /// <summary>
        /// Va afficher les stats du drone
        /// </summary>
        /// <param name="isActive">Indique si le drone est actif (en mouvement) ou s'il est simplement dans le magasin</param>
        private void DisplayStats(bool isActive)
        {
            if (isActive)
            {
                isInShop = false;
            }
            else
            {
                isInShop = true;
            }
            Console.SetCursorPosition(0, 3);
            Console.Write(this);
        }

        /// <summary>
        /// Va décrementer la batterie et augmenter sa posTop
        /// </summary>
        private void ChangeDroneValue()
        {
            if(CurrentBattery <= 0)
            {
                isDead = true;
            }
            else
            {
                CurrentBattery -= BatteryUsage;
                posLeft += 1;
            }
        }

        /// <summary>
        /// Va afficher le drone
        /// </summary>
        private void DisplayDrone(bool isDead)
        {
            if (isDead)
            {
                Console.SetCursorPosition(posLeft, posTop);
                Console.Write(SPRITEDEAD);
                Thread.Sleep(1000);
                Console.Clear();
                Interface.DisplayMenu();
            }
            else
            {
                Console.SetCursorPosition(posLeft, posTop);
                Console.Write(SPRITEALIVE);
            }
            
        }

        /// <summary>
        /// Va effacer le sprite du drone
        /// </summary>
        private void EraseSprite()
        {
            if(posLeft > 0)
            {
                Console.SetCursorPosition(posLeft -1, posTop);
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Pour débloquer le drone
        /// </summary>
        /// <returns>Si le joueur a bien débloqué le drone</returns>
        public bool UnlockDrone()
        {
            if (!isUnlocked)
            {
                isUnlocked = Money.PayDrone(DroneCost);
                if (isUnlocked)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.Write("Le drone est déjà débloqué");
                return true;
            }
            
        }

        public override string ToString()
        {
            if (isInShop)
            {
                return $"Modèle : {DroneName}\nPrix : {DroneCost}\nBatterie total : {_totalBattery}\nUtilisation de la batterie : {_batteryUsage}\nAcheter : {isUnlocked}";
            }
            else
            {
                return $"Batterie total : {_totalBattery}\nBatterie actuel : {Math.Round(_currentBattery, 2)}  \nDistance : {posLeft}\nRécompense : {moneyAward}";
            }
        }

    }
}
