import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BedWithRoom } from 'src/classes/BedWithRoom';
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
}
