using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class PatientStatus
    {
        public long Idpatient { get; set; }
        public int Idstatus { get; set; }
        public DateTime DateModification { get; set; }

        public virtual Patient IdpatientNavigation { get; set; }
        public virtual CovidStatus IdstatusNavigation { get; set; }
    }
}
