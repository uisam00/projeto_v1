import { PersonPhone } from './../../../Models/person-phone';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonPhoneService } from './../person-phone.service';

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-person-phone-create',
  templateUrl: './person-phone-create.component.html',
  styleUrls: ['./person-phone-create.component.css']
})
export class PersonPhoneCreateComponent implements OnInit {

  personPhone: PersonPhone = {
    businessEntityID: 0,
    phoneNumberTypeID: 0,
    phoneNumber: '',
  }

  constructor(private personPhoneService: PersonPhoneService,
     private router: Router,
     private route: ActivatedRoute
     ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if(id !== ''){
      this.personPhoneService.readById(id ? id : '').subscribe(personPhone => {
        this.personPhone = personPhone;
      });
    }
  }

  createOrUpdate() : void{
    if(this.personPhone.businessEntityID == null){
      this.createPersonPhone()
    } else {
      this.updatePersonPhone()
    }
  }

  updatePersonPhone() : void {
    this.personPhoneService.update(this.personPhone).subscribe(() => {
      this.personPhoneService.showMessage(`Novo número: ${this.personPhone.phoneNumber}`)
      this.router.navigate(['/person-phone'])
    })
  }

  createPersonPhone() : void {
    this.personPhoneService.create(this.personPhone).subscribe(() => {
      this.personPhoneService.showMessage(`O número: ${this.personPhone.phoneNumber} foi salv0 com sucesso`);
      this.router.navigate(['/person-phone']);
    });
  }

  cancelPersonPhone() : void {
    this.router.navigate(['/person-phone']);
  }
}
