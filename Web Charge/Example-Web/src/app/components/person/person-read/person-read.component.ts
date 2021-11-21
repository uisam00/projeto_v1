import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/Models/person';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-person-read',
  templateUrl: './person-read.component.html',
  styleUrls: ['./person-read.component.css']
})
export class PersonReadComponent implements OnInit {

  people: Person[] = [];
  displayedColumns = ['id', 'name', 'action']

  constructor(
    private personService : PersonService,
    //private spinner: NgxSpinnerService,
    //private toastr: ToastrService,

  ) { }

  ngOnInit(): void {
    this.carregarDados();
  }

  carregarDados() : void {
    this.personService.read().subscribe({
      next: (people: any) => {
        this.people = people.personObjects;
        //this.peopleFiltrados = this.people;
      },
      error: (error: any) => {
        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        //this.spinner.hide()
      },
    });
  }

}
