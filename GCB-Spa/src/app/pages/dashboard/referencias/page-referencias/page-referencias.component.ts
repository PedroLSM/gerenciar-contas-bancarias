import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Referencia } from '../referencia.model';
import { ReferenciasService } from '../referencias.service';

@Component({
  templateUrl: './page-referencias.component.html',
  styleUrls: ['./page-referencias.component.css']
})
export class PageReferenciasComponent implements OnInit {
  referencias$: Observable<Referencia[]> = this.referencias.referencias$;

  constructor(private referencias: ReferenciasService) { }

  ngOnInit(): void {
  }

}
