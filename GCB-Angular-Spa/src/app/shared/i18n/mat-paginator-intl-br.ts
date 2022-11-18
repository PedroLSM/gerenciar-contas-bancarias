import { MatPaginatorIntl } from '@angular/material/paginator';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class MatPaginatorIntlBr extends MatPaginatorIntl {
  override itemsPerPageLabel = 'Itens por página:';
  override nextPageLabel = 'Próxima página';
  override previousPageLabel = 'Página anterior';
  override lastPageLabel = 'Última página';
  override firstPageLabel = 'Primeira página';

  override getRangeLabel = (page: number, pageSize: number, length: number) => {
    if (length === 0 || pageSize === 0) {
      return '0 de ' + length;
    }

    length = Math.max(length, 0);

    const startIndex = page * pageSize;
    // If the start index exceeds the list length, do not try and fix the end index to the end.
    const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;

    return startIndex + 1 + ' - ' + endIndex + ' de ' + length;
  }

}
