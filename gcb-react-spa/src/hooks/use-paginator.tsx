import { useState } from 'react'

export interface UsePaginatorProps {
  initialState?: number;
  rowsPerPageOptions?: number[];
}

export interface PaginatorProps<T> {
  page: number;
  rowsPerPage: number;
  rowsPerPageOptions: number[];
  slice: (values: T[]) => T[];
  handleChangePage: (event: any, newPage: number) => void;
  handleChangeRowsPerPage: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

interface UsePaginatorFunction {
  <T>(props?: UsePaginatorProps): PaginatorProps<T>;
}

const usePaginator: UsePaginatorFunction = (props?: UsePaginatorProps) => {
  props = props || {};

  props.initialState = props.initialState || 0;
  props.rowsPerPageOptions = props.rowsPerPageOptions || [5, 10, 25];

  const [page, setPage] = useState(props.initialState);

  const [rowsPerPage, setRowsPerPage] = useState(props.rowsPerPageOptions[0]);

  const handleChangePage = (event: any, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const slice: <T>(rows?: T[]) => T[] = (rows) => {
    return (
      rows?.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage) || []
    );
  };

  return {
    page,
    rowsPerPage,
    rowsPerPageOptions: props.rowsPerPageOptions,
    slice,
    handleChangePage,
    handleChangeRowsPerPage,
  };
};

export default usePaginator;
