import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable, of, concat, scheduled, Scheduler, forkJoin } from 'rxjs';
import { map, shareReplay, tap, concatAll, debounceTime } from 'rxjs/operators';
import { Patient } from 'src/classes/Patient';
import { WebapiService } from 'src/services/webapi.service';
import { Anamnesis } from 'src/classes/Anamnesis';
import { AnamnesisPatient } from 'src/classes/AnamnesisPatient';
import { ReturnStatement } from '@angular/compiler';
import { ErrorService } from '../general/error.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-covid-navig',
  templateUrl: './covid-navig.component.html',
  styleUrls: ['./covid-navig.component.css']
})
export class CovidNavigComponent  {

  constructor(private breakpointObserver: BreakpointObserver, private err: ErrorService , private _snackBar: MatSnackBar) {
    this.err.NextError().pipe(
      tap(it => {
        this._snackBar.open(it, 'ERROR', {
          duration: 5000,
        });
      }),
      shareReplay()
    ).subscribe();

  }

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

    



}
