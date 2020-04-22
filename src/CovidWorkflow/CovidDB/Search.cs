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

        public Task<Patient[]> SearchPatient(string criteria)
        {
            if (criteria?.Trim()?.Length < 1)
                throw new ArgumentNullException(nameof(criteria));

            criteria = criteria.Trim();
            return context.Patient.Where(it =>
                    it.Name.Contains(criteria)
                    ||
                    it.Phone.Contains(criteria)
                    ).ToArrayAsync();
        }
    }
}
