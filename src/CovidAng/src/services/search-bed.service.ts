import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BedWithRoom, BedWithRoomAndPatient } from 'src/classes/BedWithRoom';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchBedService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  public FreeBeds(): Observable<BedWithRoom[]> {
    const url = environment.url + 'api/BedRelated/FreeBeds/';
    return this.http.get<BedWithRoom[]>(url, this.httpOptions);
  }
  public AllBedsWithPatients(): Observable<BedWithRoomAndPatient[]> {
    const url = environment.url + 'api/BedRelated/AllBedsWithPatients/';
    return this.http.get<BedWithRoomAndPatient[]>(url, this.httpOptions);

  }
}
