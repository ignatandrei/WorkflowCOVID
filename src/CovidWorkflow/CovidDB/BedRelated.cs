using CovidDB.ModelsSqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDB
{
    
    public class BedRelated
    {
        private readonly WorkflowCovidContext context;

        public BedRelated(WorkflowCovidContext context)
        {
            this.context = context;
        }

        public async Task<Bed[]> FreeBeds()
        {
            var beds = await context.Bed
               .Include(it => it.IdroomNavigation).ToArrayAsync();
            foreach (var b in beds)
            {
                b.IdroomNavigation.Bed = null;
            }
            var occupied = await context.BedPatient.Select(it => it.Idbed).ToArrayAsync();
            return beds.Where(it => !occupied.Contains(it.Idbed)).ToArray();
        }

        public async Task<Bed[]> AllBedsWithPatients()
        {
            var Beds = await context.Bed
                .Include(it => it.IdroomNavigation)              
                .Include(it=> it.BedPatient)
                //.ThenInclude(bp=>bp.IdpatientNavigation)
                .ToArrayAsync();
            foreach (var b in Beds)
            {
                b.IdroomNavigation.Bed = null;
                foreach( var bp in b.BedPatient)
                {
                    bp.IdbedNavigation = null;
                    //bp.IdpatientNavigation.BedPatient = null;                    
                }
            }
            return Beds;
        }
    }
}
