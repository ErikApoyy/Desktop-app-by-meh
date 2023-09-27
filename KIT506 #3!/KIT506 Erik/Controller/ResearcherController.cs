using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;


namespace KIT506_Erik.Controller
{
    public class ResearcherController
    {
        List<Researcher> staff;
        public List<Researcher> Workers { get { return staff; } set { } }

        public ResearcherController()
        {
            staff = Agency.LoadAll();

            //Part of step 2.3.2 in Week 9 tutorial
           
        }

         public void Display()
        {
            staff.ForEach(Console.WriteLine);
        }

    }

}

