using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class AnamnesisPatient
    {
        [Key]
        [Column("IDPatient")]
        public long Idpatient { get; set; }
        [Key]
        [Column("IDAnamnesis")]
        public long Idanamnesis { get; set; }
        [Required]
        [StringLength(500)]
        public string Details { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Idanamnesis))]
        [InverseProperty(nameof(Anamnesis.AnamnesisPatient))]
        public virtual Anamnesis IdanamnesisNavigation { get; set; }
        [ForeignKey(nameof(Idpatient))]
        [InverseProperty(nameof(Patient.AnamnesisPatient))]
        public virtual Patient IdpatientNavigation { get; set; }
    }
}
