using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeacherComputerRetrieval.Region;

namespace TeacherComputerRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            var region = new Region();

            region.AddCity("A");
            region.AddCity("B");
            region.AddCity("C");
            region.AddCity("D");
            region.AddCity("E");

            region.AddRoute("A", "B", 5);
            region.AddRoute("B", "C", 4);
            region.AddRoute("C", "D", 8);
            region.AddRoute("D", "C", 8);
            region.AddRoute("D", "E", 6);
            region.AddRoute("A", "D", 5);
            region.AddRoute("C", "E", 2);
            region.AddRoute("E", "B", 3);
            region.AddRoute("A", "E", 7);

            List<City> trip1 = new List<City>() { new City("A"), new City("B"), new City("C") };
            List<City> trip2 = new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") };
            List<City> trip3 = new List<City>() { new City("A"), new City("E"), new City("D") };

            var distance1 = region.GetDistance(trip1);
            var distance2 = region.GetDistance(trip2);
            var distance3 = region.GetDistance(trip3);

            Console.WriteLine("{0}", distance1 == 0 ? "NO SUCH ROUTE" : distance1.ToString());
            Console.WriteLine("{0}", distance2 == 0 ? "NO SUCH ROUTE" : distance2.ToString());
            Console.WriteLine("{0}", distance3 == 0 ? "NO SUCH ROUTE" : distance3.ToString());

            var routes = region.GetAllRoutes("C", "C");


            Console.WriteLine("Hello world");
        }
    }
}
