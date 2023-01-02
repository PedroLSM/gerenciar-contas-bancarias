import { useState } from 'react'
import { CreditCardOff } from '@mui/icons-material'
import { IconButton, Tooltip } from '@mui/material'

import useHttp from '../../hooks/use-http'
import DialogRetiradaBancaria from './DialogRetiradaBancaria'
import { retiradaBancaria } from '../../lib/api'
import { Extrato } from '../../models/Extrato'

const Retirar = (props: any) => {
  const { contaBancaria }: { contaBancaria: Extrato } = props;

  const [open, setOpen] = useState(false);

  const { sendRequest, status } = useHttp(retiradaBancaria);

  const clickOpenHandler = () => {
    setOpen(true);
  };

  const closeHandler = () => {
    setOpen(false);
  };

  const addRetiradaHandler = (retirada: any) => {
    const retirar = { ...retirada, extratoId: contaBancaria.extratoId };

    sendRequest(retirar).then((reponse: any) => {
      closeHandler();

      props.onRetirar(reponse.dados as Extrato);
    });
  };

  return (
    <>
      <Tooltip title="Realizar Retirada Bancária">
        <IconButton color="error" onClick={clickOpenHandler}>
          <CreditCardOff />
        </IconButton>
      </Tooltip>
      <DialogRetiradaBancaria
        open={open}
        onClose={closeHandler}
        onAddRetirada={addRetiradaHandler}
        isLoading={status === "pending"}
        nomeBanco={contaBancaria.nomeBanco}
        referenciaId={contaBancaria.referenciaId}
        extratoId={contaBancaria.extratoId}
      />
    </>
  );
};

export default Retirar;
