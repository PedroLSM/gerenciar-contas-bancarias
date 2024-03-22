import { useState } from 'react'
import { Button } from '@mui/material'
import useHttp from '../../hooks/use-http';
import { adicionarEmprestimo } from '../../lib/api';
import DialogAdicionarEmprestimo from './DialogAdicionarEmprestimo';

const AdicionarEmprestimo = (props: any) => {
  const [open, setOpen] = useState(false);

  const { sendRequest, status } = useHttp(adicionarEmprestimo);

  const clickOpenHandler = () => {
    setOpen(true);
  };

  const closeHandler = () => {
    setOpen(false);
  };

  const addEmprestimo = (emprestimo: any) => {
    sendRequest(emprestimo).then(() => {
      closeHandler();

      props.onEmprestimoAdicionado();
    });
  };

  return (
    <>
      <Button
        variant="contained"
        sx={{ height: "100%" }}
        onClick={clickOpenHandler}
      >
        Adicionar Empréstimo
      </Button>
      <DialogAdicionarEmprestimo
        open={open}
        onClose={closeHandler}
        onAddEmprestimo={addEmprestimo}
        isLoading={status === "pending"}
      />
    </>
  );
};

export default AdicionarEmprestimo;
