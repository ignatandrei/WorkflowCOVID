using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class NamePatientDetails
    {
        public NamePatientDetails()
        {
            DetailsPatient = new HashSet<DetailsPatient>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("IdnameDetailNavigation")]
        public virtual ICollection<DetailsPatient> DetailsPatient { get; set; }
    }
}
