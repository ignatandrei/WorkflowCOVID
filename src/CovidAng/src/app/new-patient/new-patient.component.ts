import { Component, OnInit } from '@angular/core';
import { WebapiService } from 'src/services/webapi.service';
import { Patient } from 'src/classes/Patient';
import { tap } from 'rxjs/operators';
import { Anamnesis } from 'src/classes/Anamnesis';
import { AnamnesisPatient } from 'src/classes/AnamnesisPatient';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-new-patient',
  templateUrl: './new-patient.component.html',
  styleUrls: ['./new-patient.component.css']
})
export class NewPatientComponent implements OnInit {


public patient: Patient;
public allAnamnesis: Anamnesis[] = [];
public resultAnam: string[] = [];
  constructor(private ws: WebapiService) { 
    this.patient = new Patient();
    ws.GetAnamnesis()
      .pipe(
        tap(it => {
          this.allAnamnesis = it.sort((a, b) => a.displayOrder - b.displayOrder);
          this.resultAnam.length = it.length;
        })
      ).subscribe();
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
    let res = toSave.map((it, index) => {
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
