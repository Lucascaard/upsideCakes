import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GerentesComponent } from './components/gerentes/gerentes.component';


const routes: Routes = [{
  path: 'gerentes', component:GerentesComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
