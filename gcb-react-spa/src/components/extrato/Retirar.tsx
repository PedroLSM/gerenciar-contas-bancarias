import { useState } from "react";
import { CreditCardOff } from "@mui/icons-material";
import { IconButton, Tooltip } from "@mui/material";

import useHttp from "../../hooks/use-http";
import DialogRetiradaBancaria from "./DialogRetiradaBancaria";
import { retiradaBancaria } from "../../lib/api";
import { Extrato } from "../../models/Extrato";
import { useDispatch } from "react-redux";
import { uiActions } from "../../store/ui-slice";

const Retirar = (props: any) => {
  const dispatch = useDispatch();

  const { contaBancaria }: { contaBancaria: Extrato } = props;

  const [open, setOpen] = useState(false);

  const { sendRequest, status, error } = useHttp(retiradaBancaria);

  const clickOpenHandler = () => {
    setOpen(true);
  };

  const closeHandler = () => {
    setOpen(false);
  };

  const addRetiradaHandler = (retirada: any) => {
    const retirar = { ...retirada, extratoId: contaBancaria.extratoId };

    sendRequest(retirar).then((response: any) => {
      if (response) {
        closeHandler();
        props.onRetirar(response.dados as Extrato);
      } else if (error) {
        dispatch(uiActions.exibirToastr({ show: true, text: error }));
      }
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
