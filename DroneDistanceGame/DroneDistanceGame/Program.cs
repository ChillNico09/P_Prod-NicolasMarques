using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneDistanceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            bool continuePlaying = Interface.ContinuePlaying;

            //Console
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            /*
            Drone cool = new Drone(100, 100, 1);
            while (true)
            {
                cool.MoveDrone();
                Thread.Sleep(100);
            }
            */
            Interface.DisplayMenu();
            
            while (continuePlaying)
            {
                Interface.UserInputHandler();
                continuePlaying = Interface.ContinuePlaying;
            }
            Environment.Exit(0);
            
        }
    }
}
