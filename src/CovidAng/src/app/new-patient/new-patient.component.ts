import { Component, OnInit } from '@angular/core';
import { WebapiService } from 'src/services/webapi.service';
import { Patient } from 'src/classes/Patient';
import { tap, last, map } from 'rxjs/operators';
import { Anamnesis } from 'src/classes/Anamnesis';
import { AnamnesisPatient } from 'src/classes/AnamnesisPatient';
import { forkJoin } from 'rxjs';
import { IdName } from 'src/classes/IdName';
import { SearchBedService } from 'src/services/search-bed.service';
import { BedWithRoom } from 'src/classes/BedWithRoom';
import { Room } from 'src/classes/Room';
import { CreateDeleteService } from 'src/services/create-delete.service';
import { PatientStatus } from 'src/classes/PatientStatus';
import { LocationPatient } from 'src/classes/LocationPatient';
import { BedPatient } from 'src/classes/BedPatient';
import { Router } from '@angular/router';
import { DetailsPatient } from 'src/classes/DetailsPatient';

@Component({
  selector: 'app-new-patient',
  templateUrl: './new-patient.component.html',
  styleUrls: ['./new-patient.component.css']
})
export class NewPatientComponent implements OnInit {


public patient: Patient;
public covidStatus = 0;
public location = 0;
public medicalTests: number[];
public DetailsPatientData: DetailsPatient[];

public allAnamnesis: Anamnesis[] = [];
public resultAnam: AnamnesisPatient[] = [];
public CovidStatus: IdName[];
public Location: IdName[];
public MedicalTest: IdName[];
public BR: Map<number, BedWithRoom[]>;
public PatientDetails: IdName[];

public idBed: number;

  constructor(private ws: WebapiService,
              private sb: SearchBedService,
              private cd: CreateDeleteService ,
              private router: Router) {
    this.patient = new Patient();
    ws.GetAnamnesis()
      .pipe(
        tap(it => {
          this.allAnamnesis = it.sort((a, b) => {
            let d = (+a.displayOrder) - (+b.displayOrder);
            if (d === 0) {
              d = a.name.localeCompare(b.name);
            }
            return d;
          });
          this.allAnamnesis.forEach(an => {
            const ap  = new AnamnesisPatient();
            ap.idanamnesis = an.id;
            this.resultAnam.push(ap);
          }
        );
        }
      )).subscribe();
    ws.GetNamePatientDetails().subscribe(it => {
        this.DetailsPatientData = [];
        for (const iterator of it) {
          const dt = new DetailsPatient();
          dt.idnameDetail = iterator.id;
          this.DetailsPatientData.push(dt);
        }
        this.PatientDetails = it;

      });
    ws.GetStatus().subscribe(it => this.CovidStatus = it);
    ws.GetLocation().subscribe(it => this.Location = it);
    ws.GetMedicalTest().subscribe(it => this.MedicalTest = it.sort((a, b) => a.name.localeCompare(b.name)));
    sb.FreeBeds()
    .pipe(tap(it => {
      this.BR = new Map<number, BedWithRoom[]>();

      for (const br of it) {
           if (!this.BR.has(br.idroom)) {
             this.BR.set(br.idroom, []);
           }
           this.BR.get(br.idroom).push(br);

      }

    }))
    .subscribe();
  }


  ngOnInit( ): void {


  }

  public savePatient() {

    this.ws.CreatePatientOrSave(this.patient)
    .pipe(
      tap(it => this.patient =  new Patient(it)),
      map(it => {
        const toSave = this.DetailsPatientData.filter(dp => dp.value?.length > 0);
        return this.cd.CreateDetailsPatient(it.id, toSave).subscribe();
      } )
    )
    .subscribe();


  }

  public patientSaved(): boolean {
    return this.patient.id > 0;
  }
  public saveAnam(): void {
    const toSave = this.resultAnam
      .filter(it => it.details?.trim().length > 0);
    this.cd.CreateAnamnesis(this.patient.id, toSave).subscribe();


  }
  public saveStatus() {
    const ps = new PatientStatus();
    ps.idpatient = this.patient.id;
    ps.idstatus = +this.covidStatus;
    console.log(ps);
    this.cd.CreateStatus(ps).subscribe();

    const ls = new LocationPatient();
    ls.idpatient = this.patient.id;
    ls.idlocation = +this.location;
    this.cd.CreateLocation(ls).subscribe();

    const bp = new BedPatient();
    bp.idpatient = this.patient.id;
    bp.idbed = +this.idBed;
    this.cd.CreateBed(bp).subscribe();

    this.router.navigateByUrl('/patient/' + this.patient.id );

  }

}
