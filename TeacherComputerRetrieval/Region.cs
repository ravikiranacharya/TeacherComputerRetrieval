using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval
{
    public class Region
    {
        public class City
        {
            private string Name { get; set; }
            private List<Route> Routes = new List<Route>();

            public City(string name)
            {
                this.Name = name;
            }

            public override string ToString()
            {
                return Name;
            }

            public void AddRoute(City endingPoint, int distance)
            {
                Routes.Add(new Route(this, endingPoint, distance));
            }

            public List<Route> GetRoutes()
            {
                return Routes;
            }
        }

        public class Route
        {
            public City StartingCity;
            public City EndingCity;
            public int Distance;

            public Route(City startingCity, City endingCity, int distance)
            {
                this.StartingCity = startingCity;
                this.EndingCity = endingCity;
                this.Distance = distance;
            }

            public override string ToString()
            {
                return StartingCity + "->" + EndingCity;
            }
        }


        private Dictionary<string, City> cities = new Dictionary<string, City>();

        public void AddCity(string name)
        {
            if (!cities.ContainsKey(name))
            {
                cities.Add(name, new City(name));
            }
        }

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

        public void Print()
        {
            foreach (var city in cities.Values)
            {
                var routes = city.GetRoutes();
                if (routes.Count > 0)
                {
                    Console.WriteLine(city + " is connected to: " + String.Join(",", routes));
                }
            }
        }

        public List<List<City>> routes;
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

        private void GetAllRoutes(City startingCity, City endingCity, Dictionary<City, bool> visitedCities, List<City> localPathList)
        {
            //visitedCities[startingCity] = true;
            if (startingCity.ToString() == endingCity.ToString())
            {
                Console.WriteLine(string.Join(",", localPathList));
                this.routes.Add(new List<City>(localPathList));
                visitedCities[startingCity] = false;
                return;
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

    }
}
