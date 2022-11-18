import { Component, OnInit } from '@angular/core';
import { Referencia } from '@models/referencia.model';
import { ReferenciasService } from '@services/referencias.service';
import { Observable } from 'rxjs';

@Component({
  templateUrl: './page-referencias.component.html',
  styleUrls: ['./page-referencias.component.scss']
})
export class PageReferenciasComponent implements OnInit {
  referencias$: Observable<Referencia[]> = this.referencias.referencias$;

  constructor(private referencias: ReferenciasService) { }

  ngOnInit(): void {
  }

}
