using CovidDB.ModelsSqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDB
{
    public class Search
    {
        private readonly WorkflowCovidContext context;

        public Search(WorkflowCovidContext context)
        {
            this.context = context;
        }

        public async Task<Patient[]> SearchPatient(string criteria)
        {
            if (criteria?.Trim()?.Length < 1)
                throw new ArgumentNullException(nameof(criteria));

            criteria = criteria.Trim();
            var det = await context
                .DetailsPatient
                .Where(it => it.Value.Contains(criteria))
                .Select(it => it.Idpatient)
                .Distinct()
                .ToArrayAsync();
            var p1= await context.Patient.Where(it =>
                    it.Name.Contains(criteria)                    
                    ).ToArrayAsync();
            var p2 = await context.Patient.Where(it => det.Contains(it.Id)).ToArrayAsync();
            return p1.Union(p2).Distinct().ToArray();
        }
    }
}
