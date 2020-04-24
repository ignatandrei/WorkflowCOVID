using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDB.ModelsSqlServer
{
    public partial class Audit
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Key]
        [StringLength(50)]
        public string TableName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTimeModified { get; set; }
        [Required]
        [StringLength(50)]
        public string KeyValues { get; set; }
        [StringLength(1000)]
        public string OldValues { get; set; }
        [StringLength(1000)]
        public string NewValues { get; set; }
        [Column("CorrelationID")]
        public Guid? CorrelationId { get; set; }
    }
}
