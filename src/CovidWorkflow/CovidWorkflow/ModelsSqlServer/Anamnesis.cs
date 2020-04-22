using System;
using System.Collections.Generic;

namespace CovidWorkflow.ModelsSqlServer
{
    public partial class Anamnesis
    {
        public Anamnesis()
        {
            AnamnesisPatient = new HashSet<AnamnesisPatient>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual ICollection<AnamnesisPatient> AnamnesisPatient { get; set; }
    }
}
