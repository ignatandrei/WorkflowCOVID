using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidDB;
using CovidDB.ModelsSqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidWorkflow.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeleteCreateController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public DeleteCreateController(WorkflowCovidContext context)
        {
            _context = context;
        }
        [HttpPost("{id}")]
        public async Task<int> Anamnesis(int id,AnamnesisPatient[] anamnesis)
        {
            var ds = new DeleteCreate(_context);
            return await ds.AnamnesisForPatient(id, anamnesis);


        }
        [HttpPost()]
        public async Task<int> Location(LocationPatient item)
        {
            var ds = new DeleteCreate(_context);
            return await ds.Location(item);


        }
        [HttpPost()]
        public async Task<int> CovidStatus(PatientStatus item)
        {
            var ds = new DeleteCreate(_context);
            return await ds.Status(item);
        }
    }
}