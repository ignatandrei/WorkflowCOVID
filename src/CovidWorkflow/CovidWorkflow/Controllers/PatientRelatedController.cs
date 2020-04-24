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
    public class PatientRelatedController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public PatientRelatedController(WorkflowCovidContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<Patient> GetDetails(long id)
        {
            var p = new PatientRelated(_context);
            return await p.FindDetails(id);
        }
    }
}