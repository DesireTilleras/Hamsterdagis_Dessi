using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd_database;
using Microsoft.EntityFrameworkCore;

namespace Hamsterdagis_Dessi
{
    public static class AddingDataInTables
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, Name = "Kallegurra Aktersnurra" },
                new Owner { Id = 2, Name = "Carl Hamilton" },
                new Owner { Id = 3, Name = "Lisa Nilsson" },
                new Owner { Id = 4, Name = "Jan Hallgren" },
                new Owner { Id = 5, Name = "Ottilla Murkwood" },
                new Owner { Id = 6, Name = "Anfers Murkwood" },
                new Owner { Id = 7, Name = "Anna Book" },
                new Owner { Id = 8, Name = "Pernilla Wahlgren" },
                new Owner { Id = 9, Name = "Bianca Ingrosso" },
                new Owner { Id = 10, Name = "Lorenzo Lamas" },
                new Owner { Id = 11, Name = "Bobby Ewing" },
                new Owner { Id = 12, Name = "Hedy Lamar" },
                new Owner { Id = 13, Name = "Bette Davis" },
                new Owner { Id = 14, Name = "Kim Carnes" },
                new Owner { Id = 15, Name = "Mork of Ork" },
                new Owner { Id = 16, Name = "Mindy Mendel" },
                new Owner { Id = 17, Name = "GW Hansson" },
                new Owner { Id = 18, Name = "Pia Hansson" },
                new Owner { Id = 19, Name = "Bo Ek" },
                new Owner { Id = 20, Name = "Anna Al" },
                new Owner { Id = 21, Name = "Hans Björk" },
                new Owner { Id = 22, Name = "Carita Gran" },
                new Owner { Id = 23, Name = "Mia Eriksson" },
                new Owner { Id = 24, Name = "Anna Linström" },
                new Owner { Id = 25, Name = "Lennart Berg" },
                new Owner { Id = 26, Name = "Bo Bergman" });

            modelBuilder.Entity<Gender>().HasData(

               new Gender { Id = 1, Gender_Type = "Female" },
               new Gender { Id = 2, Gender_Type = "Male" });

            modelBuilder.Entity<Cage>().HasData(
                new Cage { Id = 1},
                new Cage { Id = 2 },
                new Cage { Id = 3 },
                new Cage { Id = 4 },
                new Cage { Id = 5 },
                new Cage { Id = 6 },
                new Cage { Id = 7 },
                new Cage { Id = 8 },
                new Cage { Id = 9 },
                new Cage { Id = 10 });

            modelBuilder.Entity<Activity>().HasData(
                new Activity {Id = 1, Name = "Arrival"},
                new Activity {Id = 2, Name = "DayCage"},
                new Activity {Id = 3, Name = "Exercise"},
                new Activity {Id = 4, Name = "PickUp" },
                new Activity {Id = 5, Name = "Spa" }
                );

            modelBuilder.Entity<ExerciseArea>().HasData(
                new ExerciseArea { Id = 1, AmountInArea = 0});

            string[] csvLines = File.ReadAllLines("Hamsterlista30.csv");

            for (int i = 1; i < csvLines.Length; i++)
            {
                Hamster hamster = new Hamster();
                string[] data = csvLines[i].Split(';');
                hamster.Id= Convert.ToInt32(data[0]);
                hamster.Hamster_Name = data[1];
                hamster.Age = Convert.ToInt32(data[2]);
                hamster.OwnerId = Convert.ToInt32(data[5]);
                hamster.GenderId = Convert.ToInt32(data[6]);

                    modelBuilder.Entity<Hamster>().HasData(
                    new Hamster { 
                        Id = hamster.Id, 
                        Hamster_Name = hamster.Hamster_Name,
                        Age = hamster.Age,
                        OwnerId = hamster.OwnerId,
                        GenderId = hamster.GenderId
                    } );
            }
         
        }

    }

}

