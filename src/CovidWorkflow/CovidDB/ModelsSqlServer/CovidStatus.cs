using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class CovidStatus
    {
        public CovidStatus()
        {
            PatientStatus = new HashSet<PatientStatus>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("IdstatusNavigation")]
        public virtual ICollection<PatientStatus> PatientStatus { get; set; }
    }
}
