using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class BedPatient
    {
        public long Idpatient { get; set; }
        public long Idbed { get; set; }
        public DateTime? DateModification { get; set; }

        public virtual Bed IdbedNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
