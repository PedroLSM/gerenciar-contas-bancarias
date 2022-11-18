import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ExtratosService } from '@services/extratos.service';
import { ModalFormUtils } from '@shared/models/modal-form-utils';
import { tap, finalize } from 'rxjs/operators';

@Component({
  selector: 'app-modal-retirada-bancaria',
  templateUrl: './modal-retirada-bancaria.component.html',
  styleUrls: ['./modal-retirada-bancaria.component.scss']
})
export class ModalRetiradaBancariaComponent extends ModalFormUtils implements OnInit, AfterViewInit {

  nomeBanco = '';

  constructor(
    private extratosService: ExtratosService,
    fb: FormBuilder,
  ) {
    super();

    this.form = fb.group({
      descricao: ['', [Validators.required]],
      valor: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.nomeBanco = this.modalComponent?.data['extrato']['nomeBanco'];
    });
  }

  retirar() {
    if (this.validarForm()) {
      this.modalComponent.iniciarLoader();

      const formValue = this.formValue();

      formValue['extratoId'] = this.modalComponent.data['extrato']['extratoId'];

      this.extratosService.retiradaBancaria(formValue)
        .pipe(
          tap((retirada) => this.modalComponent.close(retirada)),
          finalize(() => {
            this.verificarError();
            this.habilidarBotao();

            this.modalComponent.encerrarLoader();
          })
        ).subscribe();
    }
  }

}
