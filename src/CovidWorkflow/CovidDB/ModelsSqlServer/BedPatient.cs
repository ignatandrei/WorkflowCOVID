using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class BedPatient
    {
        [Key]
        [Column("IDPatient")]
        public long Idpatient { get; set; }
        [Key]
        [Column("IDBed")]
        public long Idbed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModification { get; set; }

        [ForeignKey(nameof(Idbed))]
        [InverseProperty(nameof(Bed.BedPatient))]
        public virtual Bed IdbedNavigation { get; set; }
        [ForeignKey(nameof(Idpatient))]
        [InverseProperty(nameof(Patient.BedPatient))]
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
