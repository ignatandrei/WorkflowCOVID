using System;
using System.Collections.Generic;

namespace CovidWorkflow.ModelsSqlServer
{
    public partial class Location
    {
        public Location()
        {
            LocationPatient = new HashSet<LocationPatient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LocationPatient> LocationPatient { get; set; }
    }
}
