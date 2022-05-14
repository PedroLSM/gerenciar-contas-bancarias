export interface Mes {
  id: string;
  anoReferencia: number;
  mesReferencia: string;
  totalRetirado: number;
  totalDepositado: number;
  diferencaSaldoAnterior: number;
  saldo: number;
}

export interface Referencia {
  anoReferencia: number;
  meses: Mes[];
}
