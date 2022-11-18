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
export class ContaBancariaService extends ApiBaseService {

  adicionarContaBancaria(body: any): Observable<any> {
    return this.post(`/ContaBancaria/Adicionar`, body);
  }

  ativarContaBancaria(body: any): Observable<any> {
    return this.post(`/ContaBancaria/Ativar`, body);
  }

  desativarContaBancaria(body: any): Observable<any> {
    return this.post(`/ContaBancaria/Desativar`, body);
  }


}
