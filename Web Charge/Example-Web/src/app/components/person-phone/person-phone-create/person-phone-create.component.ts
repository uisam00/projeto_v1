import { PersonPhone } from './../../../Models/person-phone';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonPhoneService } from './../person-phone.service';

import { Component, OnInit } from '@angular/core';
import { PersonPhoneRequestDto } from 'src/app/Dtos/person-phone-request-dto';
import { PersonPhoneDto } from 'src/app/Dtos/person-phone-dto';

@Component({
  selector: 'app-person-phone-create',
  templateUrl: './person-phone-create.component.html',
  styleUrls: ['./person-phone-create.component.css']
})
export class PersonPhoneCreateComponent implements OnInit {

  selectPhoneType: any[];
  idPerson:string = '';
  idTypeNumber:string = '';
  isEdit:boolean = false;

  personPhone: PersonPhoneDto = {
    phoneNumber: '',
    phoneNumberType: null,
    businessEntityID: null,
    person: null,
    phoneNumberTypeID: null
  };

  constructor(private personPhoneService: PersonPhoneService,
     private router: Router,
     private route: ActivatedRoute
     ) { }

  ngOnInit(): void {
    this.getSelectTypeNumber();
    const idUrl = this.route.snapshot.paramMap.get('id');
    if(idUrl.indexOf(":") > -1){
      let idSplited = idUrl.split(":");
      this.idPerson = idSplited[0];
      this.idTypeNumber = idSplited[1];
      this.isEdit = true;

    }else{
      this.idPerson = idUrl;
    }

    if(this.idPerson !== '' && this.idTypeNumber !== '' ){
      this.getPersonPhoneById(this.idPerson, this.idTypeNumber);
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


  getSelectTypeNumber() {
    this.personPhoneService.findSelectTypeNumber().subscribe(  {
      next: (types: any) => {
        this.selectPhoneType = types.phoneNumberTypeObjects;
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

  createOrUpdate() : void{
    if(this.personPhone.businessEntityID == null){
      this.createPersonPhone()
    } else {
      this.updatePersonPhone()
    }
  }

  updatePersonPhone() : void {
    let request:PersonPhoneRequestDto = new PersonPhoneRequestDto();
    request.businessEntityID = parseInt(this.idPerson);
    request.phoneNumber = this.personPhone.phoneNumber;
    request.phoneNumberTypeID = this.personPhone.phoneNumberTypeID;
    
    this.personPhoneService.update(request).subscribe(  {
      next: (personPhone: any) => {
        this.personPhoneService.showMessage(`O Número foi atualizado.`)

      },
      error: (error: any) => {
        this.personPhoneService.showMessage(error.message);
        this.router.navigate(['/person-phones/'+this.idPerson])

        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        this.router.navigate(['/person-phones/'+this.idPerson])

        //this.spinner.hide()
      },
    });
  }

  
  createPersonPhone() : void {
    let request:PersonPhoneRequestDto = new PersonPhoneRequestDto();
    request.businessEntityID = parseInt(this.idPerson);
    request.phoneNumber = this.personPhone.phoneNumber;
    request.phoneNumberTypeID = this.personPhone.phoneNumberTypeID;

    this.personPhoneService.create(request).subscribe(  {
      next: (personPhone: any) => {
        this.personPhoneService.showMessage(`O número foi salvo com sucesso.`);
      },
      error: (error: any) => {
        this.personPhoneService.showMessage(error.message);
        this.router.navigate(['/person-phones/'+this.idPerson])

        //this.spinner.hide();
        //this.toastr.error('Erro ao Carregar os Pessoas', 'Erro!');
      },
      complete: () => {
        this.router.navigate(['/person-phones/'+this.idPerson])

        //this.spinner.hide()
      },
    });
  }

  cancelPersonPhone() : void {
    this.router.navigate(['/person-phones/'+this.idPerson]);
  }
}
