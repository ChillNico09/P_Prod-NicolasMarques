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
            bool isPlaying = Interface.IsPlaying;

            //Console
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            List<Drone> listDrones = new List<Drone>();
            listDrones.Add(new Drone(100, 100f, 1.1f));
            
            Interface.DisplayMenu();
            
            while (continuePlaying)
            {
                while(isPlaying)
                {
                    listDrones[0].MoveDrone();
                    Thread.Sleep(100);
                }
                Interface.UserInputHandler();
                continuePlaying = Interface.ContinuePlaying;
                isPlaying = Interface.IsPlaying;
            }
            Environment.Exit(0);
            
        }
    }
}
