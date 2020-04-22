using System;
using System.Collections.Generic;

namespace CovidWorkflow.ModelsSqlServer
{
    public partial class PatientMedicalTest
    {
        public long Idpacient { get; set; }
        public long IdmedicalTest { get; set; }
        public int IdmedicalTestStatus { get; set; }
        public string Result { get; set; }
        public DateTime DateModification { get; set; }

        public virtual MedicalTests IdmedicalTestNavigation { get; set; }
        public virtual Patient IdpacientNavigation { get; set; }
    }
}
