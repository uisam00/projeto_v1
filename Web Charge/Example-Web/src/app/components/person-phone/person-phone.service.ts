import { PersonPhone } from './person-phone.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonPhoneService {

  baseURL = "http://localhost:62504/api/"

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

  create(personPhone: PersonPhone) : Observable<PersonPhone> {
    return this.http.post<PersonPhone>(this.baseURL+'adicionar', personPhone);
  }

  read() : Observable<PersonPhone[]> {
    return this.http.get<PersonPhone[]>(this.baseURL);
  }

  readById (id: string): Observable<PersonPhone> {
    const url = `${this.baseURL}${id}`
    return this.http.get<PersonPhone>(url);
  }

  update(personPhone: PersonPhone) : Observable<PersonPhone> {
    const url = `${this.baseURL}editar`
    return this.http.post<PersonPhone>(url, personPhone);
  }

  delete(id: string) : Observable<PersonPhone> {
    const url = `${this.baseURL}deletar`
    return this.http.post<PersonPhone>(url, id);
  }
}
