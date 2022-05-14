import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'referencias', pathMatch: 'full' },
  {
    path: 'referencias',
    loadChildren: () => import('./modules/referencias.module')
      .then(m => m.ReferenciasModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
