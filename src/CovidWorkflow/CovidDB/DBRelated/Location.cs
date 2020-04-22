using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidDB.ModelsSqlServer
{
    public partial class Location
    {
        public static Location[] Create(params string[] names)
        {
            return names.Select(it => new Location()
            {
                Name = it
            }).ToArray();
        }
    }
}
