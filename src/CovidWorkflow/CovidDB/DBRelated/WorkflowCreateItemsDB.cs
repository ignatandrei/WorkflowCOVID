using CovidDB.DBRelated;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidDB.ModelsSqlServer
{
    partial class WorkflowCovidContext
    {
        public void CreateDB()
        {
            
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.NamePatientDetails.AddRange(
                ModelsSqlServer.NamePatientDetails.Create(
                    "CNP", "Telefon", "Sustinator", "TelefonSustinator","Comments"
                    ))
                ;
            this.Anamnesis.AddRange(
                ModelsSqlServer.Anamnesis.Create(
                    "Istoric fumat", "Nr PA", "medicatie personala",
                    "Obezitate",
"IMC",
"HTA",
"Diabet zaharat",
"Link epidemiologic",
"Contact COVID",
"Cu cine a avut contact",
"Expunere la noxe",
"Ce expunere",
"Alte APP",
"Febra",
"Temperatura",
"Dispnee",
"mMRC",
"Tuse",
"Anosmie",
"Fatigabilitate",
"Scaderea apetitului",
"Cefalee",
"Angina faringiana",
"Frison",
"Rinoree",
"Greata",
"Varsaturi",
"Diaree",
"Scaune diareice",
"Name",
"Debutul simptomelor"

                   )
                );

            this.CovidStatus.Add(new CovidStatus()
            {
                Name = "Suspect",
            });
            this.CovidStatus.Add(new CovidStatus()
            {
                Name = "Confirmat",
            });

            this.Location.AddRange(ModelsSqlServer.Location.Create("SpitalizareZi", "Spitalizare", "Acasa", "Iesit Evidenta"));

            this.MedicalTests.AddRange(ModelsSqlServer.MedicalTests.Create(
                "PCR SARS COV 2",
"HLG",
"VSH",
"PROT C",
"Procalcitonina",
"APTT",
"INR",
"Feritina",
"CK",
"CK-MB",
"Troponina",
"Glicemie",
"Uree",
"Creatinina",
"TGO",
"TGP",
"BT",
"BD",
"LDH",
"Hemocult",
"EAB",
"Sputa BK",
"Sputa Flora",
"GeneXpert",
"Rx Torace",
"CT Torace N",
"CT Torace K"

                ));

            this.Room.AddRange(BedsRoom.CreateRoom("1A",
"2A",
"3A",
"4A",
"5A",
"1B",
"2B",
"3B",
"4B",
"5B",
"6B",
"7B",
"8B",
"9B",
"10B",
"11B",
"12B",
"13B",
"14B",
"15B"
));
            this.Bed.AddRange(BedsRoom.CreateBed(
                (1, "Pat1"),
(1, "Pat2"),
(1, "Pat3"),
(2, "Pat1"),
(2, "Pat2"),
(3, "Pat1"),
(3, "Pat2"),
(4, "Pat1"),
(4, "Pat2"),
(4, "Pat3"),
(5, "Pat1"),
(5, "Pat2"),
(5, "Pat3"),
(5, "Pat4"),
(5, "Pat 5"),
(6, "Pat1"),
(6, "Pat2"),
(7, "Pat1"),
(7, "Pat2"),
(8, "Pat1"),
(8, "Pat2"),
(9, "Pat 1"),
(10, "Pat1"),
(10, "Pat2"),
(11, "Pat1"),
(11, "Pat2"),
(11, "Pat 3"),
(11, "Pat 4"),
(12, "Pat1"),
(12, "Pat2"),
(13, "Pat1"),
(13, "Pat2"),
(14, "Pat1"),
(14, "Pat2"),
(15, "Pat1"),
(15, "Pat2"),
(16, "Pat1"),
(16, "Pat2"),
(17, "Pat1"),
(17, "Pat2"),
(17, "Pat 3"),
(18, "Pat1"),
(18, "Pat2"),
(18, "Pat 3"),
(19, "Pat1"),
(19, "Pat2"),
(19, "Pat 3"),
(20, "Pat1"),
(20, "Pat2"),
(20, "Pat 3")

                ));
            this.SaveChanges();

        }
    }
}
