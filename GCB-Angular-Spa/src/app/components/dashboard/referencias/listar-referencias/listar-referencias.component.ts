import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Mes, Referencia } from '@models/referencia.model';
import { filter, tap } from 'rxjs/operators';
import { ModalAdicionarContaBancariaComponent } from '../modal-adicionar-conta-bancaria/modal-adicionar-conta-bancaria.component';

@Component({
  selector: 'app-listar-referencias',
  templateUrl: './listar-referencias.component.html',
  styleUrls: ['./listar-referencias.component.scss']
})
export class ListarReferenciasComponent implements OnInit {
  displayedColumns = ['anoReferencia', 'mesReferencia', 'totalRetirado', 'totalDepositado', 'saldo', 'diferencaSaldoAnterior', 'actions'];

  meses: Mes[] = [];

  private _referencias: Referencia[] = [];

  public get referencias(): Referencia[] {
    return this._referencias;
  }

  @Input('referencias')
  public set referencias(value: Referencia[]) {
    this._referencias = value;

    const referencia = this.referencias[0];

    this.meses = referencia.meses || [];
  }

  constructor(
    private dialog: MatDialog,
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  openModalContaBancaria() {
    const dialogRef = this.dialog.open(ModalAdicionarContaBancariaComponent, {
      data: {},
    });

    dialogRef.afterClosed()
      .pipe(
        filter(value => !!value),
        tap(() => location.reload())
      ).subscribe();
  }
}
