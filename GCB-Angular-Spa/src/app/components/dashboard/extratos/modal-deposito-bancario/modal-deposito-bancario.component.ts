import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ExtratosService } from '@services/extratos.service';
import { ModalFormUtils } from '@shared/models/modal-form-utils';
import { finalize, tap } from 'rxjs/operators';

@Component({
  selector: 'app-modal-deposito-bancario',
  templateUrl: './modal-deposito-bancario.component.html',
  styleUrls: ['./modal-deposito-bancario.component.scss']
})
export class ModalDepositoBancarioComponent extends ModalFormUtils implements OnInit, AfterViewInit {

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

  depositar() {
    if (this.validarForm()) {
      this.modalComponent.iniciarLoader();

      const formValue = this.formValue();

      formValue['extratoId'] = this.modalComponent.data['extrato']['extratoId'];

      this.extratosService.depositoBancario(formValue)
        .pipe(
          tap((deposito) => this.modalComponent.close(deposito)),
          finalize(() => {
            this.verificarError();
            this.habilidarBotao();

            this.modalComponent.encerrarLoader();
          })
        ).subscribe();
    }
  }
}