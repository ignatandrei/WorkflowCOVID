import { Component, OnInit } from '@angular/core';
import { WebapiService } from 'src/services/webapi.service';
import { Patient } from 'src/classes/Patient';
import { tap } from 'rxjs/operators';
import { Anamnesis } from 'src/classes/Anamnesis';
import { AnamnesisPatient } from 'src/classes/AnamnesisPatient';
import { forkJoin } from 'rxjs';
import { IdName } from 'src/classes/IdName';
import { SearchBedService } from 'src/services/search-bed.service';
import { BedWithRoom } from 'src/classes/BedWithRoom';
import { Room } from 'src/classes/Room';

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


public allAnamnesis: Anamnesis[] = [];
public resultAnam: string[] = [];
public CovidStatus: IdName[];
public Location: IdName[];
public MedicalTest: IdName[];
public BR: Map<number, BedWithRoom[]>;

  constructor(private ws: WebapiService, private sb: SearchBedService ) {
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
          this.resultAnam.length = it.length;
        })
      ).subscribe();
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
    this.ws.CreatePatient(this.patient).subscribe(
      it => this.patient = it
    );
  }

  public patientSaved(): boolean {
    return this.patient.id > 0;
  }
  public saveAnam(): void {
    const toSave = this.resultAnam;
    console.log(toSave);
    const res = toSave.map((it, index) => {
      const s = new AnamnesisPatient();
      s.idanamnesis = this.allAnamnesis[index].id;
      s.idpatient = this.patient.id;
      s.details  = this.resultAnam[index];
      return s;
    })
      .filter(it => it.details?.trim().length > 0)
      .map(it => this.ws.CreateAnamnesis(it));
    console.log(res.length);
    const obs = forkJoin(res).subscribe();



  }

}
