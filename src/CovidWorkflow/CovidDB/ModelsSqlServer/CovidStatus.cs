using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class CovidStatus
    {
        public CovidStatus()
        {
            PatientStatus = new HashSet<PatientStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PatientStatus> PatientStatus { get; set; }
    }
}
