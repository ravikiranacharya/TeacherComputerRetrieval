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

            Assert.AreEqual(9, region.GetDistance(new List<City>() { new City("A"), new City("B"), new City("C") }));
            Assert.AreEqual(22, region.GetDistance(new List<City>() { new City("A"), new City("E"), new City("B"), new City("C"), new City("D") }));
            Assert.AreNotEqual(7, region.GetDistance(new List<City>() { new City("A"), new City("E"), new City("D") }));

        }
    }
}
