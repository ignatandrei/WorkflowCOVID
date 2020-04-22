import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CovidNavigComponent } from './covid-navig/covid-navig.component';
import { SearchPatientComponent } from './search-patient/search-patient.component';
import { NewPatientComponent } from './new-patient/new-patient.component';
import { DetailsPatientComponent } from './details-patient/details-patient.component';


const routes: Routes = [
  {
    path: 'newPatient',
    component: NewPatientComponent,
    data: { title: 'Pacient nou' }
  },
  { path: '',
    redirectTo: '/newPatient',
    pathMatch: 'full'
  },
  { path: 'searchPatient', component: SearchPatientComponent },
  { path: 'patient/:id', component: DetailsPatientComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
