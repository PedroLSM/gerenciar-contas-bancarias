import { useState } from 'react'
import { Button } from '@mui/material'

import useHttp from '../../hooks/use-http'
import DialogAdicionarContaBancaria from './DialogAdicionarContaBancaria'
import { adicionarContaBancaria } from '../../lib/api'

const AdicionarContaBancaria = (props: any) => {
  const [open, setOpen] = useState(false);

  const { sendRequest, status } = useHttp(adicionarContaBancaria);

  const clickOpenHandler = () => {
    setOpen(true);
  };

  const closeHandler = () => {
    setOpen(false);
  };

  const addContaBancaria = (contaBancaria: any) => {
    sendRequest(contaBancaria).then(() => {
      closeHandler();

      props.onContaBancariaAdicionada();
    });
  };

  return (
    <>
      <Button
        variant="contained"
        sx={{ height: "100%" }}
        onClick={clickOpenHandler}
      >
        Adicionar Conta Bancária
      </Button>
      <DialogAdicionarContaBancaria
        open={open}
        onClose={closeHandler}
        onAddContaBancaria={addContaBancaria}
        isLoading={status === "pending"}
      />
    </>
  );
};

export default AdicionarContaBancaria;
