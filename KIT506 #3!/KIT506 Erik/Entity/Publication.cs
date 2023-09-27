using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;

namespace KIT506_Erik.Entity
{
    public enum OutputType
    {
        Conference,
        Journal,
        Other
    }

    public enum OutputRanking
    {
        Q1,
        Q2,
        Q3,
        Q4
    }

    public class Publication
    { 
        public string DOI { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } 
        public string Year { get; set; }
        public OutputType Type { get; set; } 
        public string CiteAs { get; set; }
        public DateTime Available { get; set; }
        public OutputRanking Ranking{ get; set; }


        public override string ToString()
        {
            return Year + "-" + Title; // Should  I override it here or put it in PublicationController?
        }

        public TimeSpan Age()
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan Age = currentDate - Available; // This calculation based on RAP pp.9-10

            return Age;
        }

        internal static void Add(Publication publication)
        {
            throw new NotImplementedException();
        }
    }
}




// -- This is from Bilal demonstration --
// THis part can be deleted, have to follow the RAP 
// When publication is created, at least 1 author should be included
// Publication can't be exist without an author

//public List<string> Author { get; set; } 

//public Publication()
//{
//    Author = new List<string>();
//}

//public void AddAuthor(string AuthorName)
//{
//    Author.Add(AuthorName);
//}
