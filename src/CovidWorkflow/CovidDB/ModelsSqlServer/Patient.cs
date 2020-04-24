using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [InverseProperty("IdpatientNavigation")]
        public virtual ICollection<AnamnesisPatient> AnamnesisPatient { get; set; }
        [InverseProperty("IdpatientNavigation")]
        public virtual ICollection<BedPatient> BedPatient { get; set; }
        [InverseProperty("IdpatientNavigation")]
        public virtual ICollection<DetailsPatient> DetailsPatient { get; set; }
        [InverseProperty("IdpatientNavigation")]
        public virtual ICollection<LocationPatient> LocationPatient { get; set; }
        [InverseProperty("IdpacientNavigation")]
        public virtual ICollection<PatientMedicalTest> PatientMedicalTest { get; set; }
        [InverseProperty("IdpatientNavigation")]
        public virtual ICollection<PatientStatus> PatientStatus { get; set; }
    }
}
