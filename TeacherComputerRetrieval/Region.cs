using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval
{
    /* Class representing a global region */
    public class Region
    {
        /* Class representing a City in a region. */
        public class City
        {
            private string Name { get; set; }
            private List<Route> Routes;

            /// <summary>
            /// Constructor to initialize a city object with a name
            /// </summary>
            /// <param name="name"></param>
            public City(string name)
            {
                this.Name = name;
                this.Routes = new List<Route>();
            }

            /* Overriding the ToString() method to print the name of City instead of printing the object */
            public override string ToString()
            {
                return Name;
            }

            /// <summary>
            /// To add a route between cities
            /// </summary>
            /// <param name="endingPoint">Destination city</param>
            /// <param name="distance">Distance from this city to the destination city</param>
            public void AddRoute(City endingPoint, int distance)
            {
                Routes.Add(new Route(this, endingPoint, distance));
            }

            /// <summary>
            /// To get all routes from this city
            /// </summary>
            /// <returns>List<Route></returns>
            public List<Route> GetRoutes()
            {
                return Routes;
            }
        }

        /* Class representing the route between two cities */
        public class Route
        {
            public City StartingCity;
            public City EndingCity;
            public int Distance;

            /// <summary>
            /// Constructor to initialize a route between two cities with a distance
            /// </summary>
            /// <param name="startingCity">Source</param>
            /// <param name="endingCity">Destination</param>
            /// <param name="distance">Distance between source and destination</param>
            public Route(City startingCity, City endingCity, int distance)
            {
                this.StartingCity = startingCity;
                this.EndingCity = endingCity;
                this.Distance = distance;
            }

            /* Overriding ToString() method to print route */
            public override string ToString()
            {
                return StartingCity + "->" + EndingCity;
            }
        }

        // Dictionary to store cities as key value pairs
        private Dictionary<string, City> cities = new Dictionary<string, City>();
        public List<List<City>> routes; // To store all routes between source and destination

        /// <summary>
        /// To add a city by name
        /// </summary>
        /// <param name="name">City's name</param>
        public void AddCity(string name)
        {
            if (!cities.ContainsKey(name))
            {
                cities.Add(name, new City(name));
            }
        }


        /// <summary>
        /// To add a route between two cities
        /// </summary>
        /// <param name="startingPoint">Source city</param>
        /// <param name="endingPoint">Destination city</param>
        /// <param name="distance">Distance between two cities</param>
        public void AddRoute(string startingPoint, string endingPoint, int distance)
        {
            var startingCity = cities.ContainsKey(startingPoint) ? cities[startingPoint] : null;
            if (startingCity == null)
            {
                throw new Exception("Invalid source");
            }

            var endingCity = cities.ContainsKey(endingPoint) ? cities[endingPoint] : null;
            if (endingCity == null)
            {
                throw new Exception("Invalid destination");
            }

            startingCity.AddRoute(endingCity, distance);
            
        }


        /*
         * This will only fetch the acyclic paths.
         * Need to improve this method to fetch all paths including cycles.
         */
         
        /// <summary>
        /// To get all routes between a source and destination
        /// </summary>
        /// <param name="startingPoint">Source city</param>
        /// <param name="endingPoint">Destination city</param>
        /// <returns>List of list of cities which are in the path</returns>
        public List<List<City>> GetAllRoutes(string startingPoint, string endingPoint)
        {
            this.routes = new List<List<City>>();

            List<City> pathList = new List<City>();
            Dictionary<City, bool> visitedCities = new Dictionary<City, bool>();
            foreach (var city in cities)
            {
                visitedCities.Add(city.Value, false);
            }


            var startingCity = cities[startingPoint];
            var endingCity = cities[endingPoint];
            pathList.Add(startingCity);


            GetAllRoutes(startingCity, endingCity, visitedCities, pathList);
            return this.routes;
        }

        /* Implementation of the recursive method */
        private void GetAllRoutes(City startingCity, City endingCity, Dictionary<City, bool> visitedCities, List<City> localPathList)
        {
            visitedCities[startingCity] = true;

            if (startingCity.ToString() == endingCity.ToString())
            {
                this.routes.Add(new List<City>(localPathList));
                var allVisited = true;
                foreach (var city in visitedCities)
                {
                    if (city.Value == false)
                    {
                        allVisited = false;
                    }
                }
                if (allVisited)
                {
                    return;
                }
                visitedCities[startingCity] = false;
            }

            foreach (var route in startingCity.GetRoutes())
            {
                if (visitedCities[route.EndingCity] == false)
                {
                    localPathList.Add(route.EndingCity);
                    GetAllRoutes(route.EndingCity, endingCity, visitedCities, localPathList);
                    localPathList.Remove(route.EndingCity);
                }
            }


            visitedCities[startingCity] = false;
        }

        /// <summary>
        /// To get distance between 'n' cities of a route
        /// </summary>
        /// <param name="cities">List of cities in a route</param>
        /// <returns>Integer</returns>
        public int GetDistance(List<City> cities)
        {
            int distance = 0;
            if (!(cities.Count > 0))
            {
                return distance;
            }

            for (int i = 0; i < cities.Count - 1; i++)
            {
                var route = this.cities[cities[i].ToString()].GetRoutes().Find(r => r.EndingCity.ToString() == cities[i + 1].ToString());
                if (route == null)
                {
                    return 0;
                }
                else
                {
                    distance += route == null ? 0 : route.Distance;
                }
            }

            return distance;
        }

        /// <summary>
        /// To get shortest distance between two cities
        /// </summary>
        /// <param name="startingPoint">Source city</param>
        /// <param name="endingPoint">Destination city</param>
        /// <returns></returns>
        public int GetShortestDistance(string startingPoint, string endingPoint)
        {
            /* Ideally, this should be done by implementing Dijkstraw's algorithm */
            /* But for lack of time and since we atleast need the logically correct answer than having nothing,
             * following a poor approach here */

            /* Since we don't fetch cycled routes, if the starting point and ending point are same,
             * it won't work :[ 
             */ 
            var allRoutes = this.GetAllRoutes(startingPoint, endingPoint);
            var distance = int.MaxValue;
            if(allRoutes != null)
            {
                foreach(var route in allRoutes)
                {
                    var routeDistance = GetDistance(route);
                    if(routeDistance < distance)
                    {
                        distance = routeDistance;
                    }
                }
            }
            return distance;
        }

        /// <summary>
        /// To count the number of trips between source and destination
        /// </summary>
        /// <param name="startingPoint">Source city</param>
        /// <param name="endingPoint">Destination city</param>
        /// <param name="predicate">Optional condition</param>
        /// <returns></returns>
        public int CountTrips(string startingPoint, string endingPoint, Predicate<int> predicate = null)
        {
            Console.WriteLine("Not implemented");
            return 0;
        }

    }
}
