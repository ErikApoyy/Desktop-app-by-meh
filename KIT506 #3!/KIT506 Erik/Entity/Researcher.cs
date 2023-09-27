using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;

namespace KIT506_Erik.Entity
{
    public class Researcher
    {
        List<Position> Positions;
        List<Publication> Publications;

        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public override string ToString()
        {
            return FamilyName + ", " + GivenName + "(" + Title + ")";
        }

        

        //All the functions start here
        //
        //

        // Should I make it string or Position(class), it shows error if I set it as Position 
        public string GetCurrentJob(Position position)
        {
            if (position != null)
            {
                string CurrentJob = "Level: " + position.Level +
                    ", Start date: " + position.StartDate +
                    ", End date: " + position.EndDate;
                return CurrentJob;
            }
            else
            {
                return "You are unemployed";
            }
        }


        public string CurrentJobTitle(Position.EmploymentLevel level)
        {
            string CurrentTitle;

            if (level == Position.EmploymentLevel.A)
            {
                CurrentTitle = "A";
            }
            else if (level == Position.EmploymentLevel.B)
            {
                CurrentTitle = "B";
            }
            else if (level == Position.EmploymentLevel.C)
            {
                CurrentTitle = "C";
            }
            else if (level == Position.EmploymentLevel.D)
            {
                CurrentTitle = "D";
            }
            else if (level == Position.EmploymentLevel.E)
            {
                CurrentTitle = "E";
            }
            else if (level == Position.EmploymentLevel.Student)
            {
                CurrentTitle = "Student";
            }
            else
            {
                CurrentTitle = "Title unknown";
            }
            return CurrentTitle;
        }

        public DateTime CurrentJobStart(Position position)
        {
            DateTime CurrentJobStart = position.StartDate;
            Console.WriteLine("Your current job start is: " + CurrentJobStart);

            return CurrentJobStart;
            // Is this a good implementation of a function??
        }


        //Not quite sure about this method, ask during consultation!!!
        public Position GetEarliestJob()
        {
            Position EarliestJob = null;

            if (Positions != null && Positions.Count > 0)
            {
                foreach (Position position in Positions)
                {
                    if (EarliestJob == null || position.StartDate < EarliestJob.StartDate)
                    {
                        EarliestJob = position;
                    }
                }
            }

            return EarliestJob;
        }


        // Not quite sure about this method as well, has to ask !!!
        public DateTime GetEarliestStart(Position StartDate)
        {
            if (Positions != null && Positions.Count > 0)
            {
                DateTime EarliestStart = Positions[0].StartDate;

                foreach (Position position in Positions)
                {
                    if (position.StartDate < EarliestStart)
                    {
                        EarliestStart = position.StartDate;
                    }
                }
                return EarliestStart;
            }
            else
            {
                return StartDate.StartDate; // They only have 1 job so it will show
                                            // the inputted date (?)
            }
        }


        // Ask the tutor about the logic of this method!
        public float Tenure() 
        {
            if (Positions != null && Positions.Count > 0)
            {
                DateTime CurrentDate = DateTime.Now;

                // Find the earliest start, same with previous method 
                DateTime EarliestStart = Positions[0].StartDate;
                foreach (Position position in Positions)
                {
                    if (position.StartDate < EarliestStart)
                    {
                        EarliestStart = position.StartDate;
                    }
                }

                TimeSpan Tenure = CurrentDate - EarliestStart;
                float TenureInYears = (float)(Tenure.TotalDays / 365.25);
                return TenureInYears;
            }
            else
            {
                return 0.0f; 
            }
        }


        public int PublicationCount()
        {
            if (Publications != null) // What the difference between null and 0?? askkk
            {
                int TotalPublication = Publications.Count;
                return TotalPublication;
            }
            else
            {
                return 0;
            }
        }

        public class Student : Researcher
        {
            public string Degree { get; set; }
        }


        public class Staff : Researcher
        {
            List<Student> StudentSupervised;

            

            public float ThreeYearAverage()
            {

                if (Publications != null)
                {
                    DateTime CurrentDate = DateTime.Now; 
                    int CurrentYear = CurrentDate.Year;

                    int StartYear = CurrentYear - 3; // 2023 - 3 = 2020.
                    int EndYear = CurrentYear - 1; // 2023 - 1 = 2022. ==> 2020, 2021, 2022

                    int TotalPublication = 0;

                    //foreach (Publication publication in Publications)
                    //{
                        //int PublicationYear = publication.Year.Year; // Make the date become year only: 2022-01-01 > 2022
                        //int PublicationYear = publication.Year;
                        //if (PublicationYear >= StartYear && PublicationYear <= EndYear)
                        //{
                            //TotalPublication++;
                        //}
                    //}

                    float AveragePublication = (float)TotalPublication / 3.0f;
                    return AveragePublication;
                } else
                {
                    return 0.0f;
                }
            }

            public float Performance()
            {
                float AveragePublication = ThreeYearAverage();

                float ExpectedNumber = 0.0f; 
                //float[] ExpectedNumber = { 0.5f, 1.0f, 2.0f, 3.2f, 4.0f };

                // Set it to student as default (Student don't have this performance)
                Position.EmploymentLevel EmployeeLevel = Position.EmploymentLevel.Student;

                switch(EmployeeLevel)
                {
                    case Position.EmploymentLevel.A:
                        ExpectedNumber = 0.5f;
                        break;
                    case Position.EmploymentLevel.B:
                        ExpectedNumber = 1.0f;
                        break;
                    case Position.EmploymentLevel.C:
                        ExpectedNumber = 2.0f;
                        break;
                    case Position.EmploymentLevel.D:
                        ExpectedNumber = 3.2f;
                        break;
                    case Position.EmploymentLevel.E:
                        ExpectedNumber = 4.0f;
                        break;
                    default:
                        ExpectedNumber = 0.0f;
                        break;
                }

                float performance = (AveragePublication / ExpectedNumber) * 100;
                return performance;
            }

        }

    }

    public class LoadResearcherDetails
    {
        List<Position> Positions;
        List<Publication> Publications;

        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + "Full name: " + GivenName + FamilyName + ", Title: " + Title + ", School: " + School;
        }
}
}