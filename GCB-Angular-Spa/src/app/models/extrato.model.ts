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