import { Router, ActivatedRoute } from "@angular/router";
import { PersonPhoneService } from "./../person-phone.service";
import { Person } from "../../../Models/person";
import { Component, OnInit } from "@angular/core";
import { PersonPhone } from "src/app/Models/person-phone";
import { PersonPhoneRequestDto } from "src/app/Dtos/person-phone-request-dto";

@Component({
  selector: 'app-person-delete',
  templateUrl: './person-phone-delete.component.html',
  styleUrls: ['./person-phone-delete.component.css']
})
export class PersonPhoneDeleteComponent implements OnInit {
  personPhone: PersonPhone;
  idPerson:string = '';
  idTypeNumber:string = '';

  constructor(
    private personPhoneService: PersonPhoneService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const idUrl = this.route.snapshot.paramMap.get('id');
    if(idUrl.indexOf(":") > -1){
      let idSplited = idUrl.split(":");
      this.idPerson = idSplited[0];
      this.idTypeNumber = idSplited[1];
      this.getPersonPhoneById(this.idPerson, this.idTypeNumber);

    }else{
      this.idPerson = idUrl;
      this.router.navigate(['/person-phones/'+this.idPerson]);
    }
  }

  getPersonPhoneById(idPerson: string, idTypeNumber: string) {
    let request:PersonPhoneRequestDto = new PersonPhoneRequestDto();
    request.businessEntityID = parseInt(idPerson);
    request.phoneNumberTypeID = parseInt(idTypeNumber);

    this.personPhoneService.readById(request).subscribe({
      next: (personPhone: any) => {
        this.personPhone = personPhone.personPhoneObject;
        //this.peopleFiltrados = this.people;
      },
      error: (error: any) => {
        this.personPhoneService.showMessage(error.message);
        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        //this.spinner.hide()
      },
    });
  }

  deletePerson() : void {
    let request:PersonPhoneRequestDto = new PersonPhoneRequestDto();
    request.businessEntityID = parseInt(this.idPerson);
    request.phoneNumberTypeID = parseInt(this.idTypeNumber);

    this.personPhoneService.delete(request).subscribe({
      next: (people: any) => {
        this.personPhoneService.showMessage(`Telefone deletada.`);
        
      },
      error: (error: any) => {
        this.personPhoneService.showMessage(error.message);
        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        this.router.navigate(['/person-phones/'+this.idPerson]);

        //this.spinner.hide()
      },
    });

  }

  cancel(): void {
    this.router.navigate(['/person-phones/'+this.idPerson]);

  }
}