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
    public class BedRelatedController : ControllerBase
    {
        private readonly WorkflowCovidContext _context;

        public BedRelatedController(WorkflowCovidContext context)
        {
            _context = context;
        }
        public async Task<Bed[]> FreeBeds()
        {
            var bedRelated = new BedRelated(_context);
            return await bedRelated.FreeBeds();
        }
        public async Task<Bed[]> AllBedsWithPatients()
        {
            var bedRelated = new BedRelated(_context);
            return await bedRelated.AllBedsWithPatients();

        }
    }
}