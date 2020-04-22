using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidDB.ModelsSqlServer
{
    public partial class MedicalTests
    {
        public static MedicalTests[] Create(params string[] names)
        {
            return names.Select(it => new MedicalTests()
            {
                Name = it
            }).ToArray();
        }
    }
}
