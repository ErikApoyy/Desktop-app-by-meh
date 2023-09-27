using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT506_Erik.Entity;
using KIT506_Erik.Controller;

namespace KIT506_Erik
{
    abstract class Agency
    {
        //Connecting with database
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //convert string to enum
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        ///connection to the database and returns
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }


        public static List<Researcher> LoadAll()
        {
            List<Researcher> staff = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader mdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name from researcher", conn);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    staff.Add(new Researcher { ID = mdr.GetInt32(0), GivenName = mdr.GetString(1) + " " + mdr.GetString(2) });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (mdr != null)
                {
                    mdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return staff;
        }

        public static List<Publication> LoadPublication()
        {
            List<Publication> publications = new List<Publication>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select doi, title, authors, type, cite_as, available from publication", conn);
                rdr = cmd.ExecuteReader();


                //rdr.GetString["Title"]
                
                while (rdr.Read())
                {
                    // DateTime year = rdr.GetDateTime(0);
                    Publication.Add(new Publication { DOI = rdr.GetString("doi"), Title = rdr.GetString("title"),
                        Author = rdr.GetString("authors"), CiteAs = rdr.GetString("cite_as"), Available = rdr.GetDateTime(1) });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return publications;

        }
        
    }

}