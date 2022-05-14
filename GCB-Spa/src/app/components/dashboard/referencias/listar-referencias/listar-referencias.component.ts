import { Component, Input, OnInit } from '@angular/core';
import { Mes, Referencia } from 'src/app/pages/dashboard/referencias/referencia.model';

@Component({
  selector: 'app-listar-referencias',
  templateUrl: './listar-referencias.component.html',
  styleUrls: ['./listar-referencias.component.css']
})
export class ListarReferenciasComponent implements OnInit {
  displayedColumns = ['anoReferencia', 'mesReferencia', 'totalRetirado', 'totalDepositado', 'saldo', 'diferencaSaldoAnterior', 'actions'];

  meses: Mes[] = [];

  @Input('referencias') referencias: Referencia[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
