import { useEffect } from 'react'
import { useParams } from 'react-router-dom'

import ListaExtrato from '../components/extrato/ListaExtrato'
import ErrorDetail from '../components/shared/ErrorDetail'
import Footer from '../components/shared/Footer'
import Title from '../components/shared/Title'
import LoadingSpinner from '../components/UI/LoadingSpinner'
import useHttp from '../hooks/use-http'
import { obterExtrato } from '../lib/api'

const ExtratoPage = () => {
  const { referenciaId } = useParams();

  const {
    sendRequest,
    status,
    error,
    data: extrato,
  } = useHttp(obterExtrato, true);

  useEffect(() => {
    sendRequest(referenciaId);
  }, [sendRequest, referenciaId]);

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
        <Title text="Extrato" />
        <ErrorDetail error={error} />
      </>
    );
  }

  return (
    <>
      <Title text="Extrato" />
      <ListaExtrato extrato={extrato} />
      <Footer to="/referencias" />
    </>
  );
};

export default ExtratoPage;
