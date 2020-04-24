using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class MedicalTests
    {
        public MedicalTests()
        {
            PatientMedicalTest = new HashSet<PatientMedicalTest>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("IdmedicalTestNavigation")]
        public virtual ICollection<PatientMedicalTest> PatientMedicalTest { get; set; }
    }
}
