import { Divider, Grid, Stack } from '@mui/material'
import { useCallback, useEffect, useState } from 'react'

import AdicionarContaBancaria from '../components/referencias/AdicionarContaBancaria'
import Despesa from '../components/referencias/Despesa'
import ListaReferencias from '../components/referencias/ListaReferencias'
import Receita from '../components/referencias/Receita'
import SelecionarAnoReferencia from '../components/referencias/SelecionarAnoReferenciaForm'
import ErrorDetail from '../components/shared/ErrorDetail'
import Title from '../components/shared/Title'
import LoadingSpinner from '../components/UI/LoadingSpinner'
import useHttp from '../hooks/use-http'
import { obterReferencias } from '../lib/api'
import { Referencia } from '../models/Referencia'

const ReferenciasPage = () => {
  const {
    sendRequest,
    status,
    error,
    data: referencias,
  } = useHttp(obterReferencias, true);

  const [referenciaAtual, setReferenciaAtual] = useState<Referencia>();

  useEffect(() => {
    sendRequest();
  }, [sendRequest]);

  const referenciaSelecionadaHandler = (referencia: Referencia) => {
    setReferenciaAtual(referencia);
  };

  const contaBancariaAdicionadaHandler = useCallback(() => {
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
        <Title text="Referências" />
        <ErrorDetail error={error} />
      </>
    );
  }

  const referencia = referenciaAtual || referencias[0];

  return (
    <>
      <Title text="Referências" />

      <Grid container>
        <Grid xs={10} item={true}>
          <SelecionarAnoReferencia
            onReferenciaSelecionada={referenciaSelecionadaHandler}
            referencias={referencias}
          />
        </Grid>
        <Grid xs={2} item={true} textAlign="center">
          <AdicionarContaBancaria
            onContaBancariaAdicionada={contaBancariaAdicionadaHandler}
          />
        </Grid>
      </Grid>

      <Divider sx={{ marginY: 2 }} />

      <Stack
        direction="row"
        spacing={10}
        alignItems="center"
        justifyContent="center"
        marginY={5}
      >
        <Receita referencia={referencia} />
        <Despesa referencia={referencia} />
      </Stack>

      <Divider sx={{ marginY: 2 }} />

      <ListaReferencias referencia={referencia} />
    </>
  );
};

export default ReferenciasPage;
