import { PersonPhone } from './../../../Models/person-phone';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonPhoneService } from './../person-phone.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-person-phone-update',
  templateUrl: './person-phone-update.component.html',
  styleUrls: ['./person-phone-update.component.css']
})
export class PersonPhoneUpdateComponent implements OnInit {

  personPhone: PersonPhone = {
    businessEntityID: 0,
    phoneNumberTypeID: 0,
    phoneNumber: '',
  }

  constructor(
    private personPhoneService: PersonPhoneService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.personPhoneService.readById(id ? id : '').subscribe(personPhone => {
      this.personPhone = personPhone;
    });
  }

  updatePersonPhone() : void {
    this.personPhoneService.update(this.personPhone).subscribe(() => {
      this.personPhoneService.showMessage(`O telefone foi atualizada com sucesso`)
      this.router.navigate(['/person-phones'])
    })
  }

  cancelPersonPhone() : void {
    this.router.navigate(['/person-phones'])
  }

}
