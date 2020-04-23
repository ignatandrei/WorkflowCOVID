import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AnamnesisPatient } from 'src/classes/AnamnesisPatient';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PatientStatus } from 'src/classes/PatientStatus';
import { LocationPatient } from 'src/classes/LocationPatient';
import { BedPatient } from 'src/classes/BedPatient';

@Injectable({
  providedIn: 'root'
})
export class CreateDeleteService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  httpOptionsText = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', responseType: 'text' as const }),

  };


  constructor(private http: HttpClient) {}
  public CreateAnamnesis(idpatient: number, ap: AnamnesisPatient[]): Observable<number> {
    const url = environment.url + 'api/DeleteCreate/Anamnesis/' + idpatient;
    return this.http.post<number>(url, ap, this.httpOptionsText);
  }
  public CreateStatus(item: PatientStatus): Observable<number> {
    const url = environment.url + 'api/DeleteCreate/CovidStatus/';
    return this.http.post<number>(url, item, this.httpOptionsText);
  }
  public CreateLocation(item: LocationPatient): Observable<number> {
    const url = environment.url + 'api/DeleteCreate/Location/';
    return this.http.post<number>(url, item, this.httpOptionsText);
  }
  public CreateBed(item: BedPatient): Observable<number> {
    const url = environment.url + 'api/DeleteCreate/Bed/';
    return this.http.post<number>(url, item, this.httpOptionsText);
  }

}
