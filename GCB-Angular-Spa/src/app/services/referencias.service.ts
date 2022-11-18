import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Referencia } from '../models/referencia.model';
import { map } from 'rxjs/operators';
import { ApiBaseService } from './api-base.service';

@Injectable({
  providedIn: 'root'
})
export class ReferenciasService extends ApiBaseService {

  public referencias$: Observable<Referencia[]> = this.get<Referencia[]>(`/Referencia`)
    .pipe(
      map((referencias) => {
        const todos: any = referencias.map(
          s => s.meses
        );

        referencias.unshift({
          anoReferencia: 0,
          meses: [].concat.apply([], todos)
        })

        return referencias;
      })
    );

}
