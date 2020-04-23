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
        public async Task<int> AnamnesisForPatient(int idPatient ,AnamnesisPatient[] anamneses)
        {
            var anamPatient =await context
                .AnamnesisPatient
                .Where(it => it.Idpatient == idPatient)
                .ToArrayAsync();
            
            foreach (var item in anamPatient)
            {
                context.AnamnesisPatient.Remove(item);
            }
            await context.SaveChangesAsync();
            var lst = new List<AnamnesisPatient>(anamneses);
            foreach (var item in lst)
            {
                item.Idpatient = idPatient;
            }
            if (lst.Count > 0)
            {
                context.AnamnesisPatient.AddRange(lst.ToArray());
                return await context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
