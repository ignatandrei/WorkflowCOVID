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
        public async Task<int> AnamnesisForPatient(int idPatient ,AnamnesisPatient[] anamneses)
        {
            bool existModif = false;
            var lst = new List<AnamnesisPatient>(anamneses);
            foreach(var item in lst)
            {
                item.Idpatient = idPatient;
            }
            var anamPatient =await context
                .AnamnesisPatient
                .Where(it => it.Idpatient == idPatient)
                .ToArrayAsync();
            
            foreach (var item in anamPatient)
            {
                existModif = true;
                var exists = lst.FirstOrDefault(it => it.Idanamnesis == item.Idanamnesis);
                if (exists == null)
                {
                    context.AnamnesisPatient.Remove(item);
                }
                else
                {
                    lst.Remove(item);

                }
            }
            if (lst.Count > 0)
            {
                existModif = true;
                context.AnamnesisPatient.AddRange(lst.ToArray());
            }
            if (existModif)
                return await context.SaveChangesAsync();
            else
                return 0;
        }
    }
}
