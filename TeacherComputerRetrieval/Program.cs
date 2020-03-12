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
            foreach (var line in input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!(String.IsNullOrWhiteSpace(line)))
                {
                    //Assuming the first char from input is starting city, second char is ending city and the rest characters denote the distance between the two cities
                    region.AddRoute(line[0].ToString(), line[1].ToString(), Convert.ToInt32(line.Substring(2, line.Length - 2)));
                }
            }

            

            /* Print answers for all the eight questions */
            List<City> firstTrip = new List<City>() { new City("A"), new City("B"), new City("C") };
            List<City> secondTrip = new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") };
            List<City> thirdTrip = new List<City>() { new City("A"), new City("E"), new City("D") };

            var distanceOfFirstTrip = region.GetDistance(firstTrip);
            var distanceOfSecondTrip = region.GetDistance(secondTrip);
            var distanceOfThirdTrip = region.GetDistance(thirdTrip);
            var routes = region.GetAllRoutes("A", "C");
            var shortestRouteFromAtoC = region.GetShortestDistance("A", "C");
            var shortestRouteFromBtoB = region.GetShortestDistance("B", "B");

            PrintDistance(distanceOfFirstTrip);
            PrintDistance(distanceOfSecondTrip);
            PrintDistance(distanceOfThirdTrip);
            var tripsFromCtoC = region.CountTrips("C", "C", count => count <= 3);
            var tripsFromAtoC = region.CountTrips("A", "C", count => count == 4);
            PrintDistance(shortestRouteFromAtoC);
            PrintDistance(shortestRouteFromBtoB);
            var tripsFromCtoCWithin30 = region.CountTrips("C", "C", distance => distance < 30);

            /* Formally exit */
            Console.WriteLine("---------------------");
            Console.WriteLine("Press any key to exit");
            Console.WriteLine("---------------------");
            var exit = Console.ReadKey();
        }

        /* Method to read input from text file */
        /* Assumption : Text file exists in the specified path */
        static string ReadInput()
        {
            return File.ReadAllText(ConfigurationManager.AppSettings["InputFilePath"]);
        }

        /// <summary>
        /// Helper method to print distance
        /// </summary>
        /// <param name="distance">Distance</param>
        static void PrintDistance(int distance)
        {
            Console.WriteLine("{0}", distance == 0 ? "NO SUCH ROUTE" : distance.ToString());
        }

    }
}
