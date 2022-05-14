import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Referencia } from './referencia.model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReferenciasService {
  private apiUrl = `${environment.gateway}/Referencia`;

  public referencias$: Observable<Referencia[]> = this.http.get<Referencia[]>(`${this.apiUrl}`)
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

  constructor(private http: HttpClient) {
  }
}
