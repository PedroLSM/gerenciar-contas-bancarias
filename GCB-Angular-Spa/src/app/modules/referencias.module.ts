import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from './shared.module';
import { PageReferenciasComponent } from '../pages/dashboard/referencias/page-referencias/page-referencias.component';
import { ReferenciasRoutingModule } from './routes/referencias-routing.module';
import { ListarReferenciasComponent } from '../components/dashboard/referencias/listar-referencias/listar-referencias.component';
import { ModalAdicionarContaBancariaComponent } from '@components/dashboard/referencias/modal-adicionar-conta-bancaria/modal-adicionar-conta-bancaria.component';

@NgModule({
  declarations: [
    PageReferenciasComponent,
    ListarReferenciasComponent,
    ModalAdicionarContaBancariaComponent,
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
