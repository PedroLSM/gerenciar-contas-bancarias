import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Extrato } from '@models/extrato.model';
import { ExtratosService } from '@services/extratos.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-page-extrato',
  templateUrl: './page-extrato.component.html',
  styleUrls: ['./page-extrato.component.scss']
})
export class PageExtratoComponent implements OnInit {

  extrato$?: Observable<Extrato[]>;

  constructor(
    private route: ActivatedRoute,
    private extratosService: ExtratosService,
  ) { }

  ngOnInit(): void {
    this.extrato$ = this.extratosService.obterExtrato(this.route.snapshot.params['referenciaGuid']);
  }

}
