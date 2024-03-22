export interface Emprestimo {
    id: string;
    devedor: string;
    dataEmprestimo: Date;
    valorEmprestimo: number;
    valorPrevisto: number;
    valorPago: number;
    valorDevendo: number;
}

export interface HistoricoPagamento {
    id: string;
    emprestimoId: string;
    dataPagamento: Date;
    valorPago: number;
}