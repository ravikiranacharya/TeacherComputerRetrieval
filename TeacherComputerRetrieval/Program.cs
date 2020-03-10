﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherComputerRetrieval.Models;

namespace TeacherComputerRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Route> routes = new List<Route>();
            routes.Add(new Route("A", "B", 5));
            routes.Add(new Route("B", "C", 4));
            routes.Add(new Route("C", "D", 8));
            routes.Add(new Route("D", "C", 8));
            routes.Add(new Route("D", "E", 6));
            routes.Add(new Route("A", "D", 5));
            routes.Add(new Route("C", "E", 2));
            routes.Add(new Route("E", "B", 3));
            routes.Add(new Route("A", "E", 7));

            Journey journey1 = new Journey(routes);
            Journey journey2 = new Journey(routes);
            Journey journey3 = new Journey(routes);

            journey1.Stops.AddRange(new List<String>() { "A", "B", "C" });
            journey2.Stops.AddRange(new List<String>() { "A", "E", "B", "C", "D" });
            journey3.Stops.AddRange(new List<String>() { "A", "E", "D" });

            journey1.CalculateDistance();
            journey2.CalculateDistance();
            journey3.CalculateDistance();




            Console.WriteLine("Hello world");
        }
    }
}
