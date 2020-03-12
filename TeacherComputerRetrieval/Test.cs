using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeacherComputerRetrieval.Region;

namespace TeacherComputerRetrieval
{
    [TestFixture]
    public class Test
    {

        public Test()
        {

        }

        [TestCase]
        public void DistanceOfRoute()
        {
            Region region = new Region();
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

            /* Expected answers for given questions */
            Assert.AreEqual(9, region.GetDistance(new List<City>() { new City("A"), new City("B"), new City("C") }));
            Assert.AreEqual(22, region.GetDistance(new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") }));
            Assert.AreNotEqual(7, region.GetDistance(new List<City>() { new City("A"), new City("E"), new City("D") }));
            Assert.AreEqual(2, region.CountTrips("C", "C", count => count <=3));
            Assert.AreEqual(3, region.CountTrips("A", "C", count => count ==4));
            Assert.AreEqual(22, region.GetDistance(new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") }));
            Assert.AreEqual(9, region.GetShortestDistance("A", "C"));
            Assert.AreEqual(9, region.GetShortestDistance("B", "B"));

            /* More test cases */

            //Route of AEB = 10
            //Route of BCDC = 20
            //Shortest route from C to A - NO SUCH ROUTE
            //Shortest route from C to E - 2

            Assert.AreEqual(10, region.GetDistance(new List<City>() { new City("A"), new City("E"), new City("B") }));
            Assert.AreEqual(20, region.GetDistance(new List<City>() { new City("B"), new City("C"), new City("D"), new City("C") }));
            Assert.AreEqual(0, region.GetShortestDistance("C", "A"));
            Assert.AreEqual(2, region.GetShortestDistance("C", "E"));


        }
    }
}
