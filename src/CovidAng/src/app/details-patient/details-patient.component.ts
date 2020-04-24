import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { WebapiService } from 'src/services/webapi.service';
import { switchMap } from 'rxjs/operators';
import { Patient, PatientDetails } from 'src/classes/Patient';

@Component({
  selector: 'app-details-patient',
  templateUrl: './details-patient.component.html',
  styleUrls: ['./details-patient.component.css']
})
export class DetailsPatientComponent implements OnInit {

  public pat: PatientDetails;
  public bed: string;
  public cnp: string;
  constructor(private route: ActivatedRoute,
              private router: Router, private ws: WebapiService) { }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
         this.ws.GetPatient(+params.get('id')))
    ).subscribe(it => {
      this.pat = it;
      if (it.bedPatient.length > 0) {
        this.bed = it.bedPatient[0].idbedNavigation.name;
      }
      const cnpArr = it.detailsPatient.filter(dp => dp.idnameDetailNavigation.name === 'CNP');
      if (cnpArr.length > 0) {
        this.cnp = cnpArr[0].value;
      }

    });
  }

}
