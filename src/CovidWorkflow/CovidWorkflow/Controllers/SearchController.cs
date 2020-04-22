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
    public class SearchController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public SearchController(WorkflowCovidContext context)
        {
            _context = context;
        }
        [HttpGet("{criteria}")]

        public async Task<Patient[]> Patient(string criteria)
        {
            var s = new Search(_context);
            return await s.SearchPatient(criteria);
        }
    }
}