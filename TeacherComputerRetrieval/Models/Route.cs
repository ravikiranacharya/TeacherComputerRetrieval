using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval.Models
{
    class Route
    {
        private string StartingAcademy { get; set; }
        private string EndingAcademy { get; set; }
        private int Distance { get; set; }

        public Route(string startingAcademy, string endingAcademy, int distance)
        {
            this.StartingAcademy = startingAcademy;
            this.EndingAcademy = endingAcademy;
            this.Distance = distance;
        }


    }
}
