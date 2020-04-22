using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidWorkflow.ModelsSqlServer
{
    public partial class WorkflowCovidContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //just for see that this partial works
        }
    }
}
