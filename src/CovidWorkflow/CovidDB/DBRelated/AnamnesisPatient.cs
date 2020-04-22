using System;
using System.Collections.Generic;
using System.Text;

namespace CovidDB.ModelsSqlServer
{
    partial class AnamnesisPatient
    {
        public AnamnesisPatient()
        {
            this.Date = DateTime.UtcNow;
        }
    }
}
