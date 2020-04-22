import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { WebapiService } from 'src/services/webapi.service';
import { switchMap } from 'rxjs/operators';
import { Patient } from 'src/classes/Patient';

@Component({
  selector: 'app-details-patient',
  templateUrl: './details-patient.component.html',
  styleUrls: ['./details-patient.component.css']
})
export class DetailsPatientComponent implements OnInit {

  public pat: Patient;
  constructor(private route: ActivatedRoute,
              private router: Router, private ws: WebapiService) { }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
         this.ws.GetPatient(+params.get('id')))
    ).subscribe(it => this.pat = it);
  }

}
