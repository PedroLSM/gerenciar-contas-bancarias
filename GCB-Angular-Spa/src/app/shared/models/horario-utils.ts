export function ajustarQuantidadeBoxes(model: any) {
    const tipoDia = obterTipoDia(model['data']);
    if (tipoDia !== model['tipoDia']) {
        model['qtdBox'] = 0;
    }
}

export function obterDataAtual() {
    return new Date().toLocaleDateString();
}

export function obterTipoDia(dt: string | Date | number, verifyWeekDay: boolean = false) {
    if (verifyWeekDay) {
        if (dt === 7) { return 3; } // DOMINGO
        if (dt === 6) { return 2; } // SABADO
        return 1; // DIAS UTEIS
    } else {
        const tipoDia = new Date(dt).getDay();
        if (tipoDia === 0) { return 3; } // DOMINGO
        if (tipoDia === 6) { return 2; } // SABADO
        return 1; // DIAS UTEIS
    }
}

export function formatDate(d: number, m: number, y: number, typeFormat: number = 0) {
    switch (typeFormat) {
        case 0:
            return `${d}/${m}/${y}`;
        case 1:
            return `${formatNumber(d)}/${formatNumber(m)}/${y}`;
        default:
            return `${formatNumber(d)}-${formatNumber(m)}-${y}`;
    }
}

export function createDate(d: number, m: number, y: number) {
    return new Date(y, m, d, 0, 0, 0);
}

function formatNumber(n: number) {
    return n < 10 ? `0${n}` : n;
}