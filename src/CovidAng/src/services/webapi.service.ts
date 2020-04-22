import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from 'src/classes/Patient';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class WebapiService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  public CreatePatient( p: Patient ): Observable<Patient> {
      const url = environment.url + 'api/Patients/';
      return this.http.post<Patient>(url, p, this.httpOptions);
  }
}
