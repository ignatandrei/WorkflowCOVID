using System;
using System.Collections.Generic;

namespace CovidDB.ModelsSqlServer
{
    public partial class Room
    {
        public Room()
        {
            Bed = new HashSet<Bed>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Bed> Bed { get; set; }
    }
}
