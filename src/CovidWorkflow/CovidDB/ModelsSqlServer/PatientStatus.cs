using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class PatientStatus:IPatient
    {
        [Key]
        [Column("IDPatient")]
        public long Idpatient { get; set; }
        [Key]
        [Column("IDStatus")]
        public int Idstatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateModification { get; set; }

        [ForeignKey(nameof(Idpatient))]
        [InverseProperty(nameof(Patient.PatientStatus))]
        public virtual Patient IdpatientNavigation { get; set; }
        [ForeignKey(nameof(Idstatus))]
        [InverseProperty(nameof(CovidStatus.PatientStatus))]
        public virtual CovidStatus IdstatusNavigation { get; set; }
    }
}
