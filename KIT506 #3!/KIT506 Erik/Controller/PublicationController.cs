using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
//using KIT506_Erik.DataSource;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;

namespace KIT506_Erik.Controller
{
	public class PublicationController
	{
		private static List<Publication> Publications = new List<Publication>();

		// Get all the publication using XmlAdapter!
		public static List<Publication> LoadAllPublications()
		{
			Publications = Agency.LoadPublication();
			if (Publications != null)
			{
				return Publications;
			}
			return null;
		}

		public static List<Publication> LoadPublicationFor(string researcher)
		{
			var pubByResearcher = from pub in Publications
								  from authors in pub.Author
								  where authors.Equals(researcher)
								  select pub;

			return pubByResearcher.ToList();
		}

		
	}
}




// This is for stage-1~

//public List<Publication> LoadPublicationFor(Researcher researcher)
//{
//	List<Publication> ResearcherPublication = Publications
//		.Where(Publication => Publication.Author == $"{researcher.GivenName} {researcher.FamilyName}")
//		.ToList();

//	return ResearcherPublication;

//}