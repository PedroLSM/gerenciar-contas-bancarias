import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from './shared.module';
import { PageExtratoComponent } from '@pages/dashboard/extratos/page-extrato/page-extrato.component';
import { ListarExtratoComponent } from '@components/dashboard/extratos/listar-extrato/listar-extrato.component';
import { ExtratosRoutingModule } from './routes/extratos-routing.module';
import { BtnExtratoComponent } from '@components/dashboard/extratos/btn-extrato/btn-extrato.component';
import { ModalDepositoBancarioComponent } from '@components/dashboard/extratos/modal-deposito-bancario/modal-deposito-bancario.component';
import { ModalRetiradaBancariaComponent } from '@components/dashboard/extratos/modal-retirada-bancaria/modal-retirada-bancaria.component';

@NgModule({
  declarations: [
    PageExtratoComponent,
    ListarExtratoComponent,
    BtnExtratoComponent,
    ModalDepositoBancarioComponent,
    ModalRetiradaBancariaComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ExtratosRoutingModule,
  ],
  exports: [
    ExtratosRoutingModule,
  ],
  providers: [],
})
export class ExtratosModule { }
