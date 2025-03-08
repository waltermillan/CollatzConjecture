import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CollatzService {

  api:string = 'http://localhost:5184/api/Collatz/Get?value='

  constructor(private http: HttpClient) { }

  generate(number:number): Observable<number[]> {
    return this.http.get<number[]>(this.api + number);
  }
}
