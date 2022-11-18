import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SimplebarComponent } from '../shared/components/simplebar/simplebar.component';
import { LoaderComponent } from '@shared/components/loader/loader.component';
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import { ToastrModule } from 'ngx-toastr';
import { LayoutModule } from '@angular/cdk/layout';
import { RouterModule } from '@angular/router';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { NgxCurrencyModule, CurrencyMaskInputMode } from 'ngx-currency';
import { NgxUpperCaseDirectiveModule } from 'ngx-upper-case-directive';

const customCurrencyMaskConfig = {
  align: 'left',
  allowNegative: true,
  allowZero: true,
  decimal: ',',
  precision: 2,
  prefix: 'R$ ',
  suffix: '',
  thousands: '.',
  nullable: true,
  min: null,
  max: null,
  inputMode: CurrencyMaskInputMode.FINANCIAL
} as any;

@NgModule({
  declarations: [
    SimplebarComponent,
    LoaderComponent,
    ModalComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxUiLoaderModule,
    LayoutModule,
    ToastrModule.forRoot({
      timeOut: 8000,
      maxOpened: 1,
      preventDuplicates: true,
      progressBar: true,
      autoDismiss: true,
      resetTimeoutOnDuplicate: true,
    }),
    RouterModule,
    NgxCurrencyModule.forRoot(customCurrencyMaskConfig),
    NgxUpperCaseDirectiveModule,
  ],
  exports: [
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SimplebarComponent,
    LoaderComponent,
    NgxUiLoaderModule,
    ToastrModule,
    LayoutModule,
    RouterModule,
    ModalComponent,
    NgxCurrencyModule,
    NgxUpperCaseDirectiveModule,
  ],
  providers: [],
})
export class SharedModule { }
