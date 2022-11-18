import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ContaBancariaService } from '@services/conta-bancaria.service';
import { ReferenciasService } from '@services/referencias.service';
import { ModalFormUtils } from '@shared/models/modal-form-utils';
import { finalize, tap } from 'rxjs/operators';

@Component({
  selector: 'app-modal-adicionar-conta-bancaria',
  templateUrl: './modal-adicionar-conta-bancaria.component.html',
  styleUrls: ['./modal-adicionar-conta-bancaria.component.scss']
})
export class ModalAdicionarContaBancariaComponent extends ModalFormUtils implements OnInit {

  readonly tipoContas = [
    { value: 'Poupanca', label: 'Poupança' },
    { value: 'Corrente', label: 'Corrente' },
    { value: 'PoupancaCorrente', label: 'Poupança e Corrente' },
    { value: 'Credito', label: 'Crédito' },
    { value: 'CreditoPoupanca', label: 'Crétido e Poupança' }
  ];

  constructor(
    private contaBancariaService: ContaBancariaService,
    fb: FormBuilder,
  ) {
    super();

    this.form = fb.group({
      nomeBanco: ['', [Validators.required]],
      tipoConta: ['', [Validators.required]],
      saldoAtual: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  adicionarConta() {
    if (this.validarForm()) {
      this.modalComponent.iniciarLoader();

      const formValue = this.formValue();

      this.contaBancariaService.adicionarContaBancaria(formValue)
        .pipe(
          tap(() => this.modalComponent.close(true)),
          finalize(() => {
            this.verificarError();
            this.habilidarBotao();

            this.modalComponent.encerrarLoader();
          })
        ).subscribe();
    }
  }

}
