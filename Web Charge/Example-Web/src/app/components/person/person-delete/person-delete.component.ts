import { Router, ActivatedRoute } from "@angular/router";
import { PersonService } from "./../person.service";
import { Person } from "./../../../Models/person";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: 'app-person-delete',
  templateUrl: './person-delete.component.html',
  styleUrls: ['./person-delete.component.css']
})
export class PersonDeleteComponent implements OnInit {
  person: Person = {
    businessEntityID: 0,
    name: ''
  }

  constructor(
    private personService: PersonService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.getPerson(id.toString());
  }

  getPerson(id: string){
    this.personService.readById(id).subscribe({
      next: (person: any) => {
        this.person.businessEntityID = person.personObject.businessEntityID;
        this.person.name = person.personObject.name;
        //this.peopleFiltrados = this.people;
      },
      error: (error: any) => {
        this.personService.showMessage(error.message);

        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        //this.spinner.hide()
      },
    });
  }

  deletePerson() : void {

    this.personService.delete(this.person.businessEntityID.toString()).subscribe({
      next: (people: any) => {
        this.personService.showMessage(`Pessoa deletada.`);
        
      },
      error: (error: any) => {
        this.personService.showMessage(error.message);

        this.router.navigate(["/person"]);

        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        this.router.navigate(["/person"]);

        //this.spinner.hide()
      },
    });

  }

  cancel(): void {
    this.router.navigate(["/person"]);
  }
}