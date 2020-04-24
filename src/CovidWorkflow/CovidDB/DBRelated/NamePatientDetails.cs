using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidDB.ModelsSqlServer
{
    public partial class NamePatientDetails
    {
        internal static NamePatientDetails[] Create(params string[] names)
        {
            return names.Select(it => new NamePatientDetails()
            {
                Name = it
            }).ToArray();
        }
    }
}
