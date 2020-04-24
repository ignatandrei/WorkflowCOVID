using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class Patient
    {
        public Patient()
        {
            AnamnesisPatient = new HashSet<AnamnesisPatient>();
            BedPatient = new HashSet<BedPatient>();
            DetailsPatient = new HashSet<DetailsPatient>();
            LocationPatient = new HashSet<LocationPatient>();
            PatientMedicalTest = new HashSet<PatientMedicalTest>();
            PatientStatus = new HashSet<PatientStatus>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<AnamnesisPatient> AnamnesisPatient { get; set; }
        public virtual ICollection<BedPatient> BedPatient { get; set; }
        public virtual ICollection<DetailsPatient> DetailsPatient { get; set; }
        public virtual ICollection<LocationPatient> LocationPatient { get; set; }
        public virtual ICollection<PatientMedicalTest> PatientMedicalTest { get; set; }
        public virtual ICollection<PatientStatus> PatientStatus { get; set; }
    }
}
