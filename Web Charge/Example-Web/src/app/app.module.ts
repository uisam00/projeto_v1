import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './components/template/nav/nav.component';
import { FooterComponent } from './components/template/footer/footer.component';
import { HeaderComponent } from './components/template/header/header.component';
import { ConfirmDialogComponent } from './components/template/confirm-dialog/confirm-dialog.component';
import { AppRoutingModule } from './app-routing.module';
import { MatButtonModule, MatCardModule, MatDialogModule, MatFormFieldModule, MatInputModule, MatListModule, MatPaginatorModule, MatSelectModule, MatSidenavModule, MatSnackBarModule, MatSortModule, MatTableModule, MatToolbarModule } from '@angular/material';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './views/home/home.component';
import { PersonPhoneCrudComponent } from './views/person-phone-crud/person-phone-crud.component';
import { PersonPhoneCreateComponent } from './components/person-phone/person-phone-create/person-phone-create.component';
import { PersonPhoneReadComponent } from './components/person-phone/person-phone-read/person-phone.component';
import { PersonPhoneUpdateComponent } from './components/person-phone/person-phone-update/person-phone-update.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    HomeComponent,
    PersonPhoneCrudComponent,
    PersonPhoneCreateComponent,
    PersonPhoneReadComponent,
    PersonPhoneUpdateComponent,
    ConfirmDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatButtonModule,
    MatSnackBarModule,
    HttpClientModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
