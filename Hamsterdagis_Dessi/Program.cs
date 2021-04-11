using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Hamsterdagis_Dessi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                hamsterContext.Database.Migrate();
            }
            Simulation simulation = new Simulation();
            PrintToConsole printToConsole = new PrintToConsole();

  
            Console.WriteLine("Welcome to Hamster Day Care Simulator!\n" +
                "\nHow many days do you want to simulate?");
            int days = int.Parse(Console.ReadLine());
            Console.WriteLine("\nSpeed: Max 2 days in 1 minute");
            Console.WriteLine("\n\nTo pause the simulation : Press enter");
            Console.WriteLine("How long do you want the simulation to take? Please answer in whole minutes ");
            int minutes = int.Parse(Console.ReadLine());
            simulation.ClearLoggFile();
            simulation.ReportEventHandler += printToConsole.PrintReport;
            simulation.EndOfDayReport += printToConsole.PrintEndOfDay;
            simulation.TimeReport += printToConsole.PrintTime;
            simulation.HamsterInfo += printToConsole.PrintHamsterInfo;

            simulation.StartSimulation(days, minutes);
            PauseOrExit(simulation);

            Console.ReadLine();

        }

        private static void PauseOrExit(Simulation simulation)
        {
            ConsoleKey input = ConsoleKey.Enter;

            while (input == ConsoleKey.Enter)
            {
                simulation.Pause();
                input = Console.ReadKey().Key;
            }
        }
    }
}
