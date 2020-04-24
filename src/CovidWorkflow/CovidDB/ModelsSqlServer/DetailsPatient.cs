using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class DetailsPatient
    {
        [Key]
        [Column("IDPatient")]
        public long Idpatient { get; set; }
        [Key]
        [Column("IDNameDetail")]
        public int IdnameDetail { get; set; }
        [Required]
        [StringLength(500)]
        public string Value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(IdnameDetail))]
        [InverseProperty(nameof(NamePatientDetails.DetailsPatient))]
        public virtual NamePatientDetails IdnameDetailNavigation { get; set; }
        [ForeignKey(nameof(Idpatient))]
        [InverseProperty(nameof(Patient.DetailsPatient))]
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
