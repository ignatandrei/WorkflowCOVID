using System;
using System.Collections.Generic;

namespace CovidWorkflow.ModelsSqlServer
{
    public partial class LocationPatient
    {
        public long Idpatient { get; set; }
        public int Idlocation { get; set; }
        public DateTime DateModif { get; set; }

        public virtual Location IdlocationNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
