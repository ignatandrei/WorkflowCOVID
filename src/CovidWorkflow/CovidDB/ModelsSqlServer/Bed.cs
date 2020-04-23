using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class Bed
    {
        public Bed()
        {
            BedPatient = new HashSet<BedPatient>();
        }

        [Key]
        [Column("IDBed")]
        public long Idbed { get; set; }
        [Column("IDRoom")]
        public int? Idroom { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey(nameof(Idroom))]
        [InverseProperty(nameof(Room.Bed))]
        public virtual Room IdroomNavigation { get; set; }
        [InverseProperty("IdbedNavigation")]
        public virtual ICollection<BedPatient> BedPatient { get; set; }
    }
}
