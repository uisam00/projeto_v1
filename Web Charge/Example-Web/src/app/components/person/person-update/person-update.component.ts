import { Person } from './../../../Models/person';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from './../person.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-person-update',
  templateUrl: './person-update.component.html',
  styleUrls: ['./person-update.component.css']
})
export class PersonUpdateComponent implements OnInit {

  person: Person = {
    businessEntityID: 0,
    name: ''
  }

  constructor(
    private personService: PersonService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.personService.readById(id ? id : '').subscribe(person => {
      this.person = person;
    });
  }

  updatePerson() : void {
    this.personService.update(this.person).subscribe(() => {
      this.personService.showMessage(`O telefone foi atualizada com sucesso`)
      this.router.navigate(['/persons'])
    })
  }

  cancelPerson() : void {
    this.router.navigate(['/persons'])
  }

}
