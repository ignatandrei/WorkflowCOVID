import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Patient } from 'src/classes/Patient';
import { WebapiService } from 'src/services/webapi.service';

@Component({
  selector: 'app-covid-navig',
  templateUrl: './covid-navig.component.html',
  styleUrls: ['./covid-navig.component.css']
})
export class CovidNavigComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private ws: WebapiService) {
    this.patient = new Patient();
  }

  public patient: Patient;

  public savePatient() {
    this.ws.CreatePatient(this.patient).subscribe(
      it => this.patient = it 
    );
  }

  public canShow(): boolean {
    return this.patient.id > 0;
  }

}
