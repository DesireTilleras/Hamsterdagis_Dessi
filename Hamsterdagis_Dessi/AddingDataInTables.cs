using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd_database;

namespace Hamsterdagis_Dessi
{
    class AddingDataInTables
    {
        public void AddingOwners()
        {
            List<Owner> OwnersList = new List<Owner>()
            {
                new Owner { Name ="Kallegurra Aktersnurra" },
                new Owner { Name = "Carl Hamilton"},
                new Owner { Name = "Lisa Nilsson"},
                new Owner { Name = "Jan Hallgren"},
                new Owner { Name = "Ottilla Murkwood"},
                new Owner { Name = "Anfers Murkwood"},
                new Owner { Name = "Anna Book"},
                new Owner { Name = "Pernilla Wahlgren"},
                new Owner { Name = "Bianca Ingrosso"},
                new Owner { Name = "Lorenzo Lamas"},
                new Owner { Name = "Bobby Ewing"},
                new Owner { Name = "Hedy Lamar"},
                new Owner { Name = "Bette Davis"},
                new Owner { Name = "Kim Carnes"},
                new Owner { Name = "Mork of Ork"},
                new Owner { Name = "Mindy Mendel"},
                new Owner { Name = "GW Hansson"},
                new Owner { Name = "Pia Hansson"},
                new Owner { Name = "Bo Ek"},
                new Owner { Name = "Anna Al"},
                new Owner { Name = "Hans Björk"},
                new Owner { Name = "Carita Gran"},
                new Owner { Name = "Mia Eriksson"},
                new Owner { Name = "Anna Linström"},
                new Owner { Name = "Lennart Berg"},
                new Owner { Name = "Bo Bergman"}
            };

            using (var hamsterContext = new HamsterAppContext())
            {
                foreach (var owner in OwnersList)
                {
                    hamsterContext.Owners.Add(owner);
                    hamsterContext.SaveChanges();
                }
            }

        }
        public void addingGenders()
        {
            var female = new Gender { Gender_Type = "Female" };
            var male = new Gender { Gender_Type = "Male" };

            using (var hamsterContext = new HamsterAppContext())
            {
                hamsterContext.Genders.Add(female);
                hamsterContext.Genders.Add(male);
                hamsterContext.SaveChanges();

            }
        }
        public void addingCages()
        {
            using (var hamsterContext = new HamsterAppContext())
            {
                Cage[] cages = new Cage[11];
                for (int i = 1; i < cages.Length; i++)
                {
                    var cageNumber = new Cage { Cage_Id = i };
                    hamsterContext.Cages.Add(cageNumber);
                }
                hamsterContext.SaveChanges();
            }
        }
    }
}
