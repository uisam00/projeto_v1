import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from'./views/home/home.component'
import { PersonPhoneCrudComponent } from './views/person-phone-crud/person-phone-crud.component'
import { PersonPhoneCreateComponent } from './components/person-phone/person-phone-create/person-phone-create.component';
import { PersonCrudComponent } from './views/person-crud/person-crud.component';
import { PersonCreateComponent } from './components/person/person-create/person-create.component';
import { PersonDeleteComponent } from './components/person/person-delete/person-delete.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "person-phones",
    component: PersonPhoneCrudComponent
  },
  {
    path: 'person-phones/create',
    component: PersonPhoneCreateComponent
  },
  {
    path: 'person-phones/edit/:id',
    component: PersonPhoneCreateComponent
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
