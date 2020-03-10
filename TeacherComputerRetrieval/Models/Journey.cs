using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval.Models
{
    class Journey
    {
        public List<string> Stops { get; set; }
        private List<Route>  Routes { get; set; }
        public Journey(List<Route> routes)
        {
            this.Stops = new List<string>();
            this.Routes = routes;
        }

        public void CalculateDistance()
        {
            bool routesFound = true;
            if(!(Routes.Count > 0)) { routesFound = false; };
            var distance = 0;
            //Check if routes exists
            for(var i=0; i< this.Stops.Count-1; i++)
            {
                Route r = Routes.Find(route => route.StartingAcademy == this.Stops[i] && route.EndingAcademy == this.Stops[i + 1]);
                if (r != null)
                {
                    distance += r.Distance;
                }
                else
                {
                    routesFound = false;
                    
                }
            }
            if(!routesFound) { Console.WriteLine("NO SUCH ROUTE"); return;  }
            Console.WriteLine(distance);
        }

    }
}
