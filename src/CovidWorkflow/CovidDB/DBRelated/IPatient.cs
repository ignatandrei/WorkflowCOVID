using System;

namespace CovidDB.ModelsSqlServer
{
    public interface IPatient
    {
        long Idpatient { get; set; }
    }
    public partial class BedPatient : IPatient
    {
        public BedPatient()
        {
            this.DateModification = DateTime.UtcNow;
        }
    }
    public partial class LocationPatient : IPatient
    {
        public LocationPatient()
        {
            this.DateModif= DateTime.UtcNow;
        }
    }
    public partial class PatientStatus : IPatient
    {
        public PatientStatus()
        {
            this.DateModification = DateTime.UtcNow;
        }
    }
    public partial class DetailsPatient : IPatient
    {
        public DetailsPatient()
        {
            this.Date = DateTime.UtcNow;
        }
    }
    partial class AnamnesisPatient : IPatient
    {
        public AnamnesisPatient()
        {
            this.Date= DateTime.UtcNow;
        }
    }
}
