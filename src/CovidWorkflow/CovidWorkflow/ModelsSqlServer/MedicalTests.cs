using System;
using System.Collections.Generic;

namespace CovidWorkflow.ModelsSqlServer
{
    public partial class MedicalTests
    {
        public MedicalTests()
        {
            PatientMedicalTest = new HashSet<PatientMedicalTest>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PatientMedicalTest> PatientMedicalTest { get; set; }
    }
}
