import { Person } from './../../Models/person';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar'
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { PersonRequestDto } from 'src/app/Dtos/person-request-dto';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private _baseURL = "http://localhost:65012/api/person"

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

  create(person: PersonRequestDto) : Observable<Person> {
    return this.http.post<Person>(this._baseURL, person).pipe(take(1));
  }

  read() : Observable<Person[]> {
    let dataReturn = this.http.get<Person[]>(this._baseURL).pipe(take(1));
    return dataReturn;
  }

  readById (id: string): Observable<Person> {
    const url = `${this._baseURL}/${id}`
    return this.http.get<Person>(url).pipe(take(1));
  }

  update(person: PersonRequestDto) : Observable<Person> {
    return this.http.put<Person>(this._baseURL, person).pipe(take(1));
  }

  delete(id: string) : Observable<any> {
    const url = `${this._baseURL}/${id}`
    return this.http.delete<any>(url).pipe(take(1));
  }
}
