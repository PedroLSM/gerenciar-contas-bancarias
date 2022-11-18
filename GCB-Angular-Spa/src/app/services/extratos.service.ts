import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiBaseService } from './api-base.service';
import { Extrato } from '@models/extrato.model';

@Injectable({
  providedIn: 'root'
})
export class ExtratosService extends ApiBaseService {

  obterExtrato(referenciaId: string): Observable<Extrato[]> {
    return this.get(`/Extrato`, { params: { 'referenciaId': `${referenciaId}` } });
  }

  retiradaBancaria(body: any): Observable<any> {
    return this.post(`/Extrato/Adicionar/RetiradaBancaria`, body);
  }

  depositoBancario(body: any): Observable<any> {
    return this.post(`/Extrato/Adicionar/DepositoBancario`, body);
  }

}
