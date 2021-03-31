using System;

namespace Hamsterdagis_Dessi
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();

            Console.WriteLine("Welcome to Hamster Day Care Simulator!\n" +
                "\nHow many days do you want to simulate?");
            int days = int.Parse(Console.ReadLine());

            Console.WriteLine("How long do you want the simulation to take? Please answer in whole minutes : ");
            int minutes = int.Parse(Console.ReadLine());
            simulation.StartSimulation(days, minutes);
            Console.ReadLine();

        }
    }
}
