import { PersonPhoneService } from './../person-phone.service';
import { PersonPhone } from './../../../Models/person-phone';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog'
@Component({
  selector: 'app-person-phone-read',
  templateUrl: './person-phone-read.component.html',
  styleUrls: ['./person-phone-read.component.css']
})
export class PersonPhoneReadComponent implements OnInit {

  personPhones: PersonPhone[] = [];
  displayedColumns = ['id', 'name', 'isGlutenFree', 'action']

  constructor(
    private personPhoneService : PersonPhoneService,
    public dialog: MatDialog,

  ) { }

  ngOnInit(): void {
    this.carregarDados();
  }

  carregarDados() : void {
    this.personPhoneService.read().subscribe(personPhone => {
      this.personPhones = personPhone;
    })
  }

  deletePersonPhone(id: string) : void {
    let phoneNumber = '';
    this.personPhoneService.readById(id ? id : '').subscribe(personPhone => {
      phoneNumber = personPhone.phoneNumber;
    })

    this.personPhoneService.delete(id).subscribe(() => {
      this.carregarDados();
      this.personPhoneService.showMessage(`O número: ${phoneNumber} foi deletado.`);
    })
  }

}
