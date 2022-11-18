import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Extrato } from '@models/extrato.model';
import { filter, tap } from 'rxjs/operators';
import { ModalDepositoBancarioComponent } from '../modal-deposito-bancario/modal-deposito-bancario.component';
import { ModalRetiradaBancariaComponent } from '../modal-retirada-bancaria/modal-retirada-bancaria.component';

@Component({
  selector: 'app-listar-extrato',
  templateUrl: './listar-extrato.component.html',
  styleUrls: ['./listar-extrato.component.scss']
})
export class ListarExtratoComponent implements OnInit {

  displayedColumns = ['nomeBanco', 'totalRetirado', 'totalDepositado', 'saldo', 'ativa', 'actions'];

  @Input('extrato') extratoContas: Extrato[] = [];

  constructor(
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
  }

  openModalDepositar(extrato: Extrato) {
    const dialogRef = this.dialog.open(ModalDepositoBancarioComponent, {
      data: { extrato },
    });

    dialogRef.afterClosed()
      .pipe(
        filter(value => !!value),
        tap((deposito) => {
          extrato.saldo = deposito.saldo;
          extrato.totalDepositado = deposito.totalDepositado;
          extrato.totalRetirado = deposito.totalRetirado;
        })
      ).subscribe();
  }

  openModalRetirar(extrato: Extrato) {
    const dialogRef = this.dialog.open(ModalRetiradaBancariaComponent, {
      data: { extrato },
    });

    dialogRef.afterClosed()
      .pipe(
        filter(value => !!value),
        tap((retirada) => {
          extrato.saldo = retirada.saldo;
          extrato.totalDepositado = retirada.totalDepositado;
          extrato.totalRetirado = retirada.totalRetirado;
        })
      ).subscribe();
  }
}
