using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class AnamnesisPatient
    {
        public long Idpatient { get; set; }
        public long Idanamnesis { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public virtual Anamnesis IdanamnesisNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
