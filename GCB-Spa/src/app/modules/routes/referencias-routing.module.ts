import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PageReferenciasComponent } from 'src/app/pages/dashboard/referencias/page-referencias/page-referencias.component';

const routes: Routes = [
  {
    path: '',
    component: PageReferenciasComponent,
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReferenciasRoutingModule { }
