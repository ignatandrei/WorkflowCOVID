using CovidDB.ModelsSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovidDB.DBRelated
{
    class BedsRoom
    {
        public static Room[] CreateRoom(params string[] names)
        {
            return names.Select(it => new Room()
            {
                Name = it
            }).ToArray();
        }
        public static Bed[] CreateBed(params (int idroom,string name)[] names)
        {
            return names.Select(it => new Bed()
            {
                Name = it.name,
                Idroom=it.idroom

            }).ToArray();
        }

    }
}
