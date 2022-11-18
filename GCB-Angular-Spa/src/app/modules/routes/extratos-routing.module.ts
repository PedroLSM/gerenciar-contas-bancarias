import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PageExtratoComponent } from '@pages/dashboard/extratos/page-extrato/page-extrato.component';

const routes: Routes = [
  {
    path: 'extrato',
    component: PageExtratoComponent,
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExtratosRoutingModule { }
