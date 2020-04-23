using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class Room
    {
        public Room()
        {
            Bed = new HashSet<Bed>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty("IdroomNavigation")]
        public virtual ICollection<Bed> Bed { get; set; }
    }
}
