namespace CovidDB.ModelsSqlServer
{
    public interface IPatient
    {
        long Idpatient { get; set; }
    }
    public partial class BedPatient : IPatient
    {

    }
    public partial class LocationPatient : IPatient
    {

    }
    public partial class PatientStatus : IPatient
    {

    }
    public partial class DetailsPatient : IPatient
    {

    }
    partial class AnamnesisPatient : IPatient
    {

    }
}
