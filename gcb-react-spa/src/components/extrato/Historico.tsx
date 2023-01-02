import { ReceiptLong } from '@mui/icons-material'
import { IconButton, Tooltip } from '@mui/material'
import { useState } from 'react'

import DialogHistoricoExtrato from './DialogHistoricoExtrato'
import { Extrato } from '../../models/Extrato'

const Historico = (props: any) => {
  const { contaBancaria }: { contaBancaria: Extrato } = props;

  const [open, setOpen] = useState(false);

  const clickOpenHandler = () => {
    setOpen(true);
  };

  const closeHandler = () => {
    setOpen(false);
  };

  return (
    <>
      <Tooltip title="Histórico">
        <IconButton color="default" onClick={clickOpenHandler}>
          <ReceiptLong />
        </IconButton>
      </Tooltip>
      <DialogHistoricoExtrato
        open={open}
        onClose={closeHandler}
        nomeBanco={contaBancaria.nomeBanco}
        extratoId={contaBancaria.extratoId}
      />
    </>
  );
};

export default Historico;
