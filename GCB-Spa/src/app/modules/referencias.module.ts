import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from './shared.module';
import { PageReferenciasComponent } from '../pages/dashboard/referencias/page-referencias/page-referencias.component';
import { ReferenciasRoutingModule } from './routes/referencias-routing.module';
import { ListarReferenciasComponent } from '../components/dashboard/referencias/listar-referencias/listar-referencias.component';

@NgModule({
  declarations: [
    PageReferenciasComponent,
    ListarReferenciasComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReferenciasRoutingModule,
  ],
  exports: [
    ReferenciasRoutingModule,
  ],
  providers: [],
})
export class ReferenciasModule { }
