using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidDB.ModelsSqlServer
{
    public partial class Anamnesis
    {
        public static Anamnesis[] Create(params string[] names)
        {
            return names.Select(it => new Anamnesis()
            {
                Name = it
            }).ToArray();
        }
    }
}
