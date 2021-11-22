import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from'./views/home/home.component'
import { PersonPhoneCreateComponent } from './components/person-phone/person-phone-create/person-phone-create.component';
import { PersonCrudComponent } from './views/person-crud/person-crud.component';
import { PersonCreateComponent } from './components/person/person-create/person-create.component';
import { PersonDeleteComponent } from './components/person/person-delete/person-delete.component';
import { PersonPhoneReadComponent } from './components/person-phone/person-phone-read/person-phone-read.component';
import { PersonPhoneDeleteComponent } from './components/person-phone/person-phone-delete/person-phone-delete.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "person-phones/:id",
    component: PersonPhoneReadComponent
  },
  {
    path: 'person-phones/create/:id',
    component: PersonPhoneCreateComponent
  },
  {
    path: 'person-phones/edit/:id',
    component: PersonPhoneCreateComponent
  },
  {
    path: 'person-phones/delete/:id',
    component:PersonPhoneDeleteComponent
  },
  {
  path: "person",
    component: PersonCrudComponent
  },
  {
    path: 'person/create',
    component:PersonCreateComponent
  },
  {
    path: 'person/edit/:id',
    component:PersonCreateComponent
  },
  {
    path: 'person/delete/:id',
    component:PersonDeleteComponent
  }
  // {
  //   path: 'person-phones/editar/:id',
  //   component:PersonPhoneUpdateComponent
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
