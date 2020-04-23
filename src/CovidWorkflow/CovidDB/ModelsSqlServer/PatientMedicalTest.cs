using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class PatientMedicalTest
    {
        [Key]
        [Column("IDPacient")]
        public long Idpacient { get; set; }
        [Key]
        [Column("IDMedicalTest")]
        public long IdmedicalTest { get; set; }
        [Column("IDMedicalTestStatus")]
        public int IdmedicalTestStatus { get; set; }
        [StringLength(50)]
        public string Result { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateModification { get; set; }

        [ForeignKey(nameof(IdmedicalTest))]
        [InverseProperty(nameof(MedicalTests.PatientMedicalTest))]
        public virtual MedicalTests IdmedicalTestNavigation { get; set; }
        [ForeignKey(nameof(Idpacient))]
        [InverseProperty(nameof(Patient.PatientMedicalTest))]
        public virtual Patient IdpacientNavigation { get; set; }
    }
}
