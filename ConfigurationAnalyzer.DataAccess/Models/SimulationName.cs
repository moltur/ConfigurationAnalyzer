using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class SimulationName
    {
        public SimulationName()
        {
            SimulationHistory = new HashSet<SimulationHistory>();
        }

        public int SimulationNameId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public virtual ICollection<SimulationHistory> SimulationHistory { get; set; }
    }
}
