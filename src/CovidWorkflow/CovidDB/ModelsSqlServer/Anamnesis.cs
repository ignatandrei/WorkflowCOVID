using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class Anamnesis
    {
        public Anamnesis()
        {
            AnamnesisPatient = new HashSet<AnamnesisPatient>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int? DisplayOrder { get; set; }

        [InverseProperty("IdanamnesisNavigation")]
        public virtual ICollection<AnamnesisPatient> AnamnesisPatient { get; set; }
    }
}
