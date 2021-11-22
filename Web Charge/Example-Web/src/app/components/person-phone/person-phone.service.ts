import { PersonPhone } from './../../Models/person-phone';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar'
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { PersonPhoneRequestDto } from 'src/app/Dtos/person-phone-request-dto';

@Injectable({
  providedIn: 'root'
})
export class PersonPhoneService {

  private _baseURL = "http://localhost:65012/api/"

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

  findSelectTypeNumber(): Observable<any> {
    return this.http.get<any>(this._baseURL+'PhoneNumberType').pipe(take(1));
  }

  create(personPhone: PersonPhoneRequestDto) : Observable<any> {
    return this.http.post<any>(this._baseURL+"PersonPhone", personPhone).pipe(take(1));
  }

  read() : Observable<any> {
    return this.http.get<any>(this._baseURL).pipe(take(1));
  }

  readById (request: PersonPhoneRequestDto): Observable<any> {
    const url = `${this._baseURL}PersonPhone/GetById`
    return this.http.post<any>(url, request).pipe(take(1));
  }

  readByPersonId (id: string): Observable<any> {
    const url = `${this._baseURL}PersonPhone/GetByPersonId/${id}`
    return this.http.get<any>(url).pipe(take(1));
  }

  update(request: PersonPhoneRequestDto) : Observable<any> {
    const url = `${this._baseURL}PersonPhone`
    return this.http.put<any>(url, request).pipe(take(1));
  }

  delete(request: PersonPhoneRequestDto)  {
    const url = `${this._baseURL}PersonPhone/Delete`
    return this.http.post<any>(url, request).pipe(take(1));
  }
}
