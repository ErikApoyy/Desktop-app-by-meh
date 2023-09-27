using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;

namespace KIT506_Erik
{
    public class Program
    {
        static void Main(string[] args)
        {
            // List<Publication> publications = Agency.LoadPublication();
            List<Position> positions = new List<Position>();
            List<Researcher> researchers = Agency.LoadAll();
            PublicationController publicationController = new PublicationController();

            //DemoSearchByLinq();
            DemoInMemorySearch();
        }

        private static void DemoSearchByLinq()
        {

        }

        private static List<Publication> DemoInMemorySearch()
        {
            List<Publication> filteredPublications;


            filteredPublications = PublicationController.LoadPublicationFor("Mary Lister");


            return filteredPublications;

            Console.ReadLine();
        }
    }
}





// STAGE-1!!!
//THis one for publication controller 
//foreach (var researcher in researchers)
//{
//    List<Publication> TestResearchControl = publicationController.LoadPublicationFor(researcher);

//    Console.WriteLine($"Publication that belongs to {researcher.GivenName} {researcher.FamilyName} is:");
//    foreach (var publication in TestResearchControl)
//    {
//        Console.WriteLine($"DOI: {publication.DOI}, which called {publication.Title} \n");
//    }

//}

//ResearcherController researchersD = new ResearcherController();
//researchersD.Display(); //Load researcher() from researcher controller!
//Console.WriteLine("\n");
