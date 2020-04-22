import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from 'src/classes/Patient';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  public SearchPatient( s: string): Observable<Patient[]> {
    const url = environment.url + 'api/search/patient/' + s;
    return this.http.get<Patient[]>(url, this.httpOptions);
  }
}
