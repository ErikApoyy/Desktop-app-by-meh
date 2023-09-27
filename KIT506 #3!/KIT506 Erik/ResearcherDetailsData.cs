using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;


namespace KIT506_Erik
{
    abstract class ResearcherDetailsData
    {
        public static List<LoadResearcherDetails> Generate()
        {
            {
                return new List<LoadResearcherDetails>() {
                new LoadResearcherDetails { ID = 1, GivenName = "Jane", FamilyName = "Doe", Title = "Dr", School = "ICT", Campus ="Hobart", Email ="Jane@utas.edu.au" },
                new LoadResearcherDetails { ID = 2, GivenName = "John", FamilyName = "Sina", Title = "Mr", School = "Nursing", Campus ="Launceston", Email ="John@utas.edu.au" },
                new LoadResearcherDetails { ID = 3, GivenName = "Mary", FamilyName = "Goblin", Title = "Ms ", School = "Civil", Campus ="Cradle Coast", Email ="Mary@utas.edu.au" },
                new LoadResearcherDetails { ID = 4, GivenName = "Kamal", FamilyName = "Hasan", Title = "Dr", School = "ICT", Campus ="Hobart", Email ="Kamal@utas.edu.au" },
                new LoadResearcherDetails { ID = 5, GivenName = "Jake", FamilyName = "Dan", Title = "Mr",  School = "Math", Campus ="Launceston", Email ="Jake@utas.edu.au"}
            };
            }
        }
    }
}

