import { useCallback, useEffect } from 'react'
import { obterEmprestimos } from '../lib/api';
import useHttp from '../hooks/use-http';
import LoadingSpinner from '../components/UI/LoadingSpinner';
import Title from '../components/shared/Title';
import ErrorDetail from '../components/shared/ErrorDetail';
import { Divider, Grid } from '@mui/material';
import ListaEmprestimos from '../components/emprestimos/ListaEmprestimos';
import AdicionarEmprestimo from '../components/emprestimos/AdicionarEmprestimo';

const EmprestimosPage = () => {
  const {
    sendRequest,
    status,
    error,
    data: emprestimos,
  } = useHttp(obterEmprestimos, true);

  useEffect(() => {
    sendRequest();
  }, [sendRequest]);

  const emprestimoAdicionadaHandler = useCallback(() => {
    sendRequest();
  }, [sendRequest]);

  if (status === "pending") {
    return (
      <div className="centered">
        <LoadingSpinner />
      </div>
    );
  }

  if (error) {
    return (
      <>
        <Title text="Empréstimos" />
        <ErrorDetail error={error} />
      </>
    );
  }

  return (
    <>
      <Grid container>
        <Grid xs={10} item={true}>
          <Title text="Empréstimos" hiddenDivider={true} />
        </Grid>

        <Grid xs={2} item={true} textAlign="center">
          <AdicionarEmprestimo
            onEmprestimoAdicionado={emprestimoAdicionadaHandler} />
        </Grid>
      </Grid>

      <Divider sx={{ marginY: 2 }} />

      <ListaEmprestimos emprestimos={emprestimos} />
    </>
  );
};

export default EmprestimosPage;
