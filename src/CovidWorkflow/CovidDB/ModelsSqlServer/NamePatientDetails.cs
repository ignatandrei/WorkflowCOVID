using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class NamePatientDetails
    {
        public NamePatientDetails()
        {
            DetailsPatient = new HashSet<DetailsPatient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DetailsPatient> DetailsPatient { get; set; }
    }
}
