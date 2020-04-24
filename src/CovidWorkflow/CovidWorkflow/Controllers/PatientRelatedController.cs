using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidDB.ModelsSqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidWorkflow.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientRelatedController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<Patient> GetDetails(long id)
        {

        }
    }
}