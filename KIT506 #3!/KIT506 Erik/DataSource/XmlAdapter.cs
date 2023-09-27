using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;
using System.Xml;
using System.Xml.Linq;

namespace KIT506_Erik.DataSource
{
	public static class XmlAdapter
	{
        // Absolute path!
        // This only applied on mac, windows based PC has to use different path, '\\' instead of '/'
        //private static readonly string filePath = @"/Desktop/Master of IT/ KIT506 Software App Design/ Assignment #3/ KIT506 #3!/ KIT506 Erik/ DataSource/ kit206.xml";

        // Relative path!
        private static readonly string filePath = "DataSource/Fundings_Rankings.xml";

        public static List<Researcher> LoadAllFunds()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);

            //List<Publication> publications = new List<Publication>();
            List<Researcher> FundReceieved = new List<Researcher>();

            //What is this? Ask for clarity 
            XmlNodeList publicationNode = xml.SelectNodes("/Publications/Publication");

            foreach(XmlNode node in publicationNode)
            {
                Publication publication = new Publication();
                publication.DOI = node.Attributes["doi"].Value;
                publication.Title = node["Title"].InnerText;
                // publication.Year = DateTime.Parse(node["Year"].InnerText);
                // WHy in the database its string??
                // Ask is it gonna work this way?

                publication.Available = DateTime.Parse(node["AvailableFrom"].InnerText); //Converting date in string to DateTime 
                publication.Type = (OutputType)Enum.Parse(typeof(OutputType), node["Type"].InnerText); //Converting string to Enumeration
                publication.Ranking = (OutputRanking)Enum.Parse(typeof(OutputRanking), node["Ranking"].InnerText); //Converting string to Enumeration 


                // I think RAP doesn't have this, ask later !!
                // RAP only 1 author for 1 researcher
                //XmlNodeList authorNodes = node.SelectNodes("Author"); // Building a list of Author names as individual string items
                //foreach (XmlNode authorNode in authorNodes)
                //{
                //    publication.AddAuthorName(authorNode.InnerText);
                //}
                //publications.Add(publication);
            }

            return publications;

        }     
    }
}

