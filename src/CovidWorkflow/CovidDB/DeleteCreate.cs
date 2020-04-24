using CovidDB.ModelsSqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDB
{
    public class DeleteCreate
    {
        private readonly WorkflowCovidContext context;

        public DeleteCreate(WorkflowCovidContext context)
        {
            this.context = context;
        }
        public async Task<int> Bed(BedPatient item)
        {
            return await context.DeleteDataPatient(context.BedPatient, item);
        }
        public async Task<int> Location(LocationPatient item)
        {
            return await context.DeleteDataPatient(context.LocationPatient, item);
        }
        public async Task<int> Status(PatientStatus item)
        {
            return await context.DeleteDataPatient(context.PatientStatus, item);
            //var st = await context.PatientStatus.FirstOrDefaultAsync(it => it.Idpatient == ps.Idpatient);
            //if(st != null)
            //{
            //    context.PatientStatus.Remove(st);
            //    await context.SaveChangesAsync();
            //}
            //context.PatientStatus.Add(ps);
            //return await context.SaveChangesAsync();

        }
        public async Task<int> AnamnesisForPatient(int idPatient, AnamnesisPatient[] items)
        {
            if (items?.Length < 1)
                return 0;
            foreach (var item in items)
            {
                item.Idpatient = idPatient;
            }
            return await context.DeleteDataPatient(context.AnamnesisPatient, items);
        }
        public async Task<int> DetailsPatient(int idPatient, DetailsPatient[] items)
        {
            if (items?.Length < 1)
                return 0;
            foreach (var item in items)
            {
                item.Idpatient = idPatient;
            }
            return await context.DeleteDataPatient(context.DetailsPatient, items);


        }
    }
}
