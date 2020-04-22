import { Component, OnInit } from '@angular/core';
import { SearchService } from 'src/services/search.service';
import { Patient } from 'src/classes/Patient';
import { ThrowStmt } from '@angular/compiler';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-search-patient',
  templateUrl: './search-patient.component.html',
  styleUrls: ['./search-patient.component.css']
})
export class SearchPatientComponent implements OnInit {
  public Search: string ;
  public foundPat: Patient[];
  constructor(private ss: SearchService) { }

  ngOnInit(): void {
  }
  public searchPatient() {
      this.ss.SearchPatient(this.Search)
      .pipe(
        tap(it => this.foundPat = it)
      )
      .subscribe();
  }

}

