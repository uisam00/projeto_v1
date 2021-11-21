import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'

@Component({
  selector: 'app-person-phone-crud',
  templateUrl: './person-phone-crud.component.html',
  styleUrls: ['./person-phone-crud.component.css']
})
export class PersonPhoneCrudComponent implements OnInit {

  constructor(private router: Router) {

  }

  ngOnInit(): void {
  }

  navigateToPersonPhoneCreate(): void {
    this.router.navigate(['/person-phones/create']);
  }

}
