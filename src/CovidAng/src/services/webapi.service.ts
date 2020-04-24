import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from 'src/classes/Patient';
import { environment } from 'src/environments/environment';
import { Anamnesis } from 'src/classes/Anamnesis';
import { AnamnesisPatient } from 'src/classes/AnamnesisPatient';
import { IdName } from 'src/classes/IdName';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root',
})
export class WebapiService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http: HttpClient) {}

  public CreatePatientOrSave(p: Patient): Observable<Patient> {
    const url = environment.url + 'api/Patients/';
    if ((+p.id) > 0) {
       return this.http.put<Patient>(url + p.id, p, this.httpOptions).pipe
       (
         map( _ => p)
       );
    }
    return this.http.post<Patient>(url, p, this.httpOptions);
  }
  public GetPatient(id: number): Observable<Patient> {
    const url = environment.url + 'api/Patients/' + id;
    return this.http.get<Patient>(url, this.httpOptions);
  }
  public GetAnamnesis(): Observable<Anamnesis[]> {
    const url = environment.url + 'api/Anamnesis/';
    return this.http.get<Anamnesis[]>(url, this.httpOptions);
  }
    public GetStatus(): Observable<IdName[]> {
    const url = environment.url + 'api/CovidStatus/';
    return this.http.get<IdName[]>(url, this.httpOptions);
  }
  public GetLocation(): Observable<IdName[]> {
    const url = environment.url + 'api/Locations/';
    return this.http.get<IdName[]>(url, this.httpOptions);
  }
  public GetMedicalTest(): Observable<IdName[]> {
    const url = environment.url + 'api/MedicalTests/';
    return this.http.get<IdName[]>(url, this.httpOptions);
  }
  public GetNamePatientDetails(): Observable<IdName[]> {
    const url = environment.url + 'api/NamePatientDetails/';
    return this.http.get<IdName[]>(url, this.httpOptions);
  }
}
