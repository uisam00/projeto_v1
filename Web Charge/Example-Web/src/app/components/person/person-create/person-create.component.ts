import { Person } from '../../../Models/person';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../person.service';
import { Component, OnInit } from '@angular/core';
import { PersonRequestDto } from 'src/app/Dtos/person-request-dto';

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.css']
})
export class PersonCreateComponent implements OnInit {

  person: Person = {
    businessEntityID: null,
    name: '',
  }

  constructor(private personService: PersonService,
     private router: Router,
     private route: ActivatedRoute
     ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if(id != null ){
      this.getPersonById(id);
    }
  }

  getPersonById(id: string) {
    this.personService.readById(id).subscribe({
      next: (people: any) => {
        this.person = people.personObject;
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

  createOrUpdate() : void{
    if(this.person.businessEntityID == null){
      this.createPerson()
    } else {
      this.updatePerson()
    }
  }

  updatePerson() : void {

    let requestCreatPerson = new PersonRequestDto();
    requestCreatPerson.name = this.person.name;
    requestCreatPerson.businessEntityID = this.person.businessEntityID;
    this.personService.update(requestCreatPerson).subscribe({
      next: (people: any) => {
        this.person = people.personObject;
        //this.peopleFiltrados = this.people;
        this.personService.showMessage(`Pessoa atualizada`)

      },
      error: (error: any) => {
        this.router.navigate(['/person']);

        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        this.router.navigate(['/person']);
        //this.spinner.hide()
      },
    });
  }

  createPerson() : void {
    let requestCreatPerson = new PersonRequestDto();
    requestCreatPerson.name = this.person.name;
    this.personService.create(requestCreatPerson).subscribe({
      next: (people: any) => {
        this.person = people.personObject;
        //this.peopleFiltrados = this.people;
        this.personService.showMessage(`Pessoa salva com sucesso`);
      },
      error: (error: any) => {
        this.router.navigate(['/person']);

        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        this.router.navigate(['/person']);
        //this.spinner.hide()
      },
    });
  }

  cancelPerson() : void {
    this.router.navigate(['/person']);
  }
}
