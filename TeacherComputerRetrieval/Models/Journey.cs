using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval.Models
{
    class Journey
    {
        private List<string> Stops { get; set; }

        public Journey()
        {
            this.Stops = new List<string>();
        }
    }
}
