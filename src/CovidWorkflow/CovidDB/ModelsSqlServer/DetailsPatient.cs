using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class DetailsPatient
    {
        public long Idpatient { get; set; }
        public int IdnameDetail { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }

        public virtual NamePatientDetails IdnameDetailNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
