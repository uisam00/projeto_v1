import { PersonPhoneService } from '../person-phone.service';
import { Component, OnInit } from '@angular/core';
import { PersonPhoneDto } from 'src/app/Dtos/person-phone-dto';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-person-phone-read',
  templateUrl: './person-phone-read.component.html',
  styleUrls: ['./person-phone-read.component.css']
})
export class PersonPhoneReadComponent implements OnInit {

  personPhones: PersonPhoneDto[] = [];
  idPerson: string;
  displayedColumns = ['phoneNumber', 'typePhoneNumber', 'action']

  constructor(
    private personPhoneService : PersonPhoneService,
    private router: Router,
    private route: ActivatedRoute

  ) { }

  ngOnInit(): void {
    this.idPerson = this.route.snapshot.paramMap.get('id');
    this.loadData(this.idPerson);
  }

  loadData(id: string) : void {
    this.personPhoneService.readByPersonId(id).subscribe(  {
      next: (personPhones: any) => {
        this.personPhones = personPhones.personPhoneObjects;
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

}
