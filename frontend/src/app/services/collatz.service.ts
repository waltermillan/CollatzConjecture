import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CollatzConjecture } from '../models/collatz-conjecture';

@Injectable({
  providedIn: 'root'
})
export class CollatzService {

  api:string = 'http://localhost:5184/api/CollatzConjecture'

  constructor(private http: HttpClient) { }

  generate(number:number): Observable<number[]> {
    const url = `http://localhost:5184/service?value=${number}`;
    return this.http.get<number[]>(url);
  }

  add(collatzConjecture:CollatzConjecture): Observable<CollatzConjecture[]> {
    return this.http.post<CollatzConjecture[]>(this.api, collatzConjecture);
  }
}
