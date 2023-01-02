export interface Extrato {
  extratoId: string;
  contaBancariaId: string;
  referenciaId: string;
  nomeBanco: string;
  saldo: number;
  totalDepositado: number;
  totalRetirado: number;
  ativa: boolean;
}

export interface HistoricoExtrato {
  operacaoId: string;
  extratoId: string;
  descricao: string;
  valor: number;
  dataRegistro: Date;
  tipoOperacao: string;
}

export interface ContaTransferencia {
  extratoId: string;
  contaBancariaId: string;
  referenciaId: string;
  nomeBanco: string;
}
