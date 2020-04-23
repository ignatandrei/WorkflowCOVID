using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class LocationPatient: IPatient
    {
        [Key]
        [Column("IDPatient")]
        public long Idpatient { get; set; }
        [Key]
        [Column("IDLocation")]
        public int Idlocation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateModif { get; set; }

        [ForeignKey(nameof(Idlocation))]
        [InverseProperty(nameof(Location.LocationPatient))]
        public virtual Location IdlocationNavigation { get; set; }
        [ForeignKey(nameof(Idpatient))]
        [InverseProperty(nameof(Patient.LocationPatient))]
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
