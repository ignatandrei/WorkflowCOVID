using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class Location
    {
        public Location()
        {
            LocationPatient = new HashSet<LocationPatient>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("IdlocationNavigation")]
        public virtual ICollection<LocationPatient> LocationPatient { get; set; }
    }
}
