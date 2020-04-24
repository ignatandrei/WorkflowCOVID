using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class Audit
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public Guid? CorrelationId { get; set; }
    }
}
