import { AddCard } from '@mui/icons-material'
import { IconButton, Tooltip } from '@mui/material'
import { useState } from 'react'

import useHttp from '../../hooks/use-http'
import DialogDepositoBancario from './DialogDepositoBancario'
import { depositoBancario } from '../../lib/api'
import { Extrato } from '../../models/Extrato'

const Depositar = (props: any) => {
  const { contaBancaria }: { contaBancaria: Extrato } = props;

  const [open, setOpen] = useState(false);

  const { sendRequest, status } = useHttp(depositoBancario);

  const clickOpenHandler = () => {
    setOpen(true);
  };

  const closeHandler = () => {
    setOpen(false);
  };

  const addDepositoHandler = (deposito: any) => {
    const depositar = { ...deposito, extratoId: contaBancaria.extratoId };

    sendRequest(depositar).then((reponse: any) => {
      closeHandler();

      props.onDepositar(reponse.dados as Extrato);
    });
  };

  return (
    <>
      <Tooltip title="Realizar Depósito Bancário">
        <IconButton color="success" onClick={clickOpenHandler}>
          <AddCard />
        </IconButton>
      </Tooltip>
      <DialogDepositoBancario
        open={open}
        onClose={closeHandler}
        onAddDeposito={addDepositoHandler}
        isLoading={status === "pending"}
        nomeBanco={contaBancaria.nomeBanco}
      />
    </>
  );
};

export default Depositar;
