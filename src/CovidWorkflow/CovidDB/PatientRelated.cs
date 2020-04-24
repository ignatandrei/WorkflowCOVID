using CovidDB.ModelsSqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidDB
{
    public class PatientRelated
    {
        private readonly WorkflowCovidContext context;

        public PatientRelated(WorkflowCovidContext context)
        {
            this.context = context;
        }
        public async Task<Patient> FindDetails(long id)
        {
            var p = await this.context.Patient
                .Include(it => it.AnamnesisPatient)
                    .ThenInclude(ap => ap.IdanamnesisNavigation)
                .Include(it => it.DetailsPatient)
                    .ThenInclude(ap => ap.IdnameDetailNavigation)
                .Include(it=>it.PatientStatus)
                    .ThenInclude(ap=>ap.IdstatusNavigation)
                .Include(it=>it.BedPatient)
                    .ThenInclude(ap=>ap.IdbedNavigation)
                .Include(it=>it.PatientMedicalTest)
                    .ThenInclude(ap=>ap.IdmedicalTestNavigation)
                .Include(it=>it.LocationPatient)
                    .ThenInclude(it=>it.IdlocationNavigation)
                .FirstOrDefaultAsync(it => it.Id == id);

            if(p != null)
            {
                foreach(var item in p.AnamnesisPatient)
                {
                    item.IdpatientNavigation = null;
                    item.IdanamnesisNavigation.AnamnesisPatient = null;
                    
                }
                foreach (var item in p.DetailsPatient)
                {
                    item.IdpatientNavigation = null;
                    item.IdnameDetailNavigation.DetailsPatient= null;

                }
                foreach (var item in p.PatientStatus)
                {
                    item.IdpatientNavigation = null;
                    item.IdstatusNavigation.PatientStatus= null;

                }
                foreach (var item in p.BedPatient)
                {
                    item.IdpatientNavigation = null;
                    item.IdbedNavigation.BedPatient= null;

                }
                foreach (var item in p.PatientMedicalTest)
                {
                    item.IdpacientNavigation= null;
                    item.IdmedicalTestNavigation.PatientMedicalTest= null;

                }
                foreach (var item in p.LocationPatient)
                {
                    item.IdpatientNavigation= null;
                    item.IdlocationNavigation.LocationPatient= null;

                }
            }
            return p;
        }
    }
}
