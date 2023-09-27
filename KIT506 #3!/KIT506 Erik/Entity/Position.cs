using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;

namespace KIT506_Erik.Entity
{
    public class Position
    { 
        public enum EmploymentLevel
        {
            Student,
            A,
            B,
            C,
            D,
            E
        }

        public EmploymentLevel Level { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        
        public string Title()
        {
            string TitleLevel;

            switch (Level)
            {
                case EmploymentLevel.A:
                    TitleLevel = "A";
                    break;
                case EmploymentLevel.B:
                    TitleLevel = "B";
                    break;
                case EmploymentLevel.C:
                    TitleLevel = "C";
                    break;
                case EmploymentLevel.D:
                    TitleLevel = "D";
                    break;
                case EmploymentLevel.E:
                    TitleLevel = "E";
                    break;
                case EmploymentLevel.Student:
                    TitleLevel = "Student";
                    break;
                default:
                    TitleLevel = "Unknown";
                    break;
            }

            return TitleLevel;
        }



        public string ToTitle()
        {
            string JobTitle;

            switch (Level)
            {
                case EmploymentLevel.Student:
                    JobTitle = "Student";
                    break;
                case EmploymentLevel.A:
                    JobTitle = "Research Associate";
                    break;
                case EmploymentLevel.B:
                    JobTitle = "Lecture";
                    break;
                case EmploymentLevel.C:
                    JobTitle = "Assistant Professor";
                    break;
                case EmploymentLevel.D:
                    JobTitle = "Associate Professor";
                    break;
                case EmploymentLevel.E:
                    JobTitle = "Professor";
                    break;
                default:
                    JobTitle = "Unknown position";
                    break;
            }

            return JobTitle;
        }
    }
}
