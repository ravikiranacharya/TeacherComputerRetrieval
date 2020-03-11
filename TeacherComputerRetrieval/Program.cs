using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static TeacherComputerRetrieval.Region;
using System.Configuration;

namespace TeacherComputerRetrieval
{
    class Program
    {
        /* Program execution starts here */
        static void Main(string[] args)
        {
            //Initialize Region Object
            var region = new Region();
            
            //Read input from user
            string input = ReadInput();
            
            //Get all cities from input and add the distinct cities to the region
            string distinct = new String(input.Distinct().ToArray());
            foreach (var city in distinct)
            {
                if (char.IsLetter(city)) //Check if the character is a letter. We don't want to add cities for numeric characters
                {
                    region.AddCity(city.ToString()); 
                }
            }

            //For each line, add a route between the two cities with the distance
            foreach(var line in input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!(String.IsNullOrWhiteSpace(line)))
                {
                    //Assuming the first char from input is starting city, second char is ending city and the rest characters denote the distance between the two cities
                    region.AddRoute(line[0].ToString(), line[1].ToString(), Convert.ToInt32(line.Substring(2, line.Length - 2)));
                }
            }


            List<City> trip1 = new List<City>() { new City("A"), new City("B"), new City("C") };
            List<City> trip2 = new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") };
            List<City> trip3 = new List<City>() { new City("A"), new City("E"), new City("D") };

            var distance1 = region.GetDistance(trip1);
            var distance2 = region.GetDistance(trip2);
            var distance3 = region.GetDistance(trip3);

            Console.WriteLine("{0}", distance1 == 0 ? "NO SUCH ROUTE" : distance1.ToString());
            Console.WriteLine("{0}", distance2 == 0 ? "NO SUCH ROUTE" : distance2.ToString());
            Console.WriteLine("{0}", distance3 == 0 ? "NO SUCH ROUTE" : distance3.ToString());

            var routes = region.GetAllRoutes("A", "C");


            Console.WriteLine("Hello world");
        }

        static string ReadInput()
        {
            return File.ReadAllText(ConfigurationManager.AppSettings["InputFilePath"]);
        }

    }
}
