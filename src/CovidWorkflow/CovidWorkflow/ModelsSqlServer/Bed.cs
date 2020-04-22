using System;
using System.Collections.Generic;

namespace CovidWorkflow.ModelsSqlServer
{
    public partial class Bed
    {
        public Bed()
        {
            BedPatient = new HashSet<BedPatient>();
        }

        public long Idbed { get; set; }
        public int? Idroom { get; set; }
        public string Name { get; set; }

        public virtual Room IdroomNavigation { get; set; }
        public virtual ICollection<BedPatient> BedPatient { get; set; }
    }
}
