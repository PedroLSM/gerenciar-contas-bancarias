import { TablePagination } from '@mui/material'

import { PaginatorProps } from '../../hooks/use-paginator'

const Paginator = (props: PaginatorProps<any> & { count: any }) => {
  return (
    <TablePagination
      component="div"
      page={props.page}
      count={props.count || 0}
      rowsPerPage={props.rowsPerPage}
      rowsPerPageOptions={props.rowsPerPageOptions}
      onPageChange={props.handleChangePage}
      onRowsPerPageChange={props.handleChangeRowsPerPage}
      labelRowsPerPage="Itens por página:"
      labelDisplayedRows={({ from, to, count }) =>
        "" + from + "-" + to + " de " + count
      }
    />
  );
};

export default Paginator;
