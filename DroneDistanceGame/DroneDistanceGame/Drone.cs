using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDistanceGame
{
    internal class Drone
    {
        //Variables
        private const string SPRITEALIVE = "x-0-x";
        private const string SPRITEDEAD = "|-x-|";

        private bool isDead;
        private int posTop = 0;
        private int posLeft = 0;

        private int _totalBattery;
        private float _currentBattery;
        private float _batteryUsage;

        //Arguments
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
        public Drone(int totalBattery, float currentBattery, float batteryUsage)
        {
            this.TotalBattery = totalBattery;
            this.CurrentBattery = currentBattery;
            this.BatteryUsage = batteryUsage;

            isDead = false;
            posLeft = 0;
            posTop = 0;
        }

        public void MoveDrone()
        {
            EraseSprite();
            DisplayDrone();
            CurrentBattery -= BatteryUsage;
            posLeft += 1;
        }


        /// <summary>
        /// Va afficher le drone
        /// </summary>
        private void DisplayDrone()
        {
            Console.SetCursorPosition(posLeft, posTop);
            Console.Write(SPRITEALIVE);
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

        public override string ToString()
        {
            return $"Batterie total: {_totalBattery}\nBatterie actuel: {_currentBattery}\nUtilisation de la batterie: {_batteryUsage}";
        }
    }
}
