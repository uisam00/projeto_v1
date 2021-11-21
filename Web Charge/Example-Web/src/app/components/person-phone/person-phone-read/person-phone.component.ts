import { PersonPhoneService } from './../person-phone.service';
import { PersonPhone } from './../../../Models/person-phone';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog'
import { ConfirmDialogComponent } from '../../template/confirm-dialog/confirm-dialog.component';

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
    let nomePersonPhone = '';
    this.personPhoneService.readById(id ? id : '').subscribe(personPhone => {
      nomePersonPhone = personPhone.name;
    })

    this.personPhoneService.delete(id).subscribe(() => {
      this.carregarDados();
      this.personPhoneService.showMessage(`O número: ${nomePersonPhone} foi deletado.`);
    })
  }

  openDialog(id: string): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width:'350px',
      data: 'Tem certeza que quer excluir esse dado?'
    })
    dialogRef.afterClosed().subscribe(res => {
      if(res){
        this.deletePersonPhone(id);

      }
    })
  }

}
