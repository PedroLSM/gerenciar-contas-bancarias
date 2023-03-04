import { useState } from "react";
import { UploadFile } from "@mui/icons-material";
import { IconButton, Tooltip } from "@mui/material";

import useHttp from "../../hooks/use-http";
import { Extrato } from "../../models/Extrato";
import DialogCarregarExtrato from "./DialogCarregarExtrato";
import { carregarExtrato } from "../../lib/api";
import { useDispatch } from "react-redux";
import { uiActions } from "../../store/ui-slice";

const CarregarExtrato = (props: any) => {
  const dispatch = useDispatch();

  const { contaBancaria }: { contaBancaria: Extrato } = props;

  const [open, setOpen] = useState(false);

  const { sendRequest, status, error } = useHttp(carregarExtrato);

  const clickOpenHandler = () => {
    setOpen(true);
  };

  const closeHandler = () => {
    setOpen(false);
  };

  const addExtratoHandler = (retirada: any) => {
    const retirar = { ...retirada, extratoId: contaBancaria.extratoId };

    sendRequest(retirar).then((response: any) => {
      // console.log("response", response);
      if (response) {
        closeHandler();
        props.onCarregar(response.dados as Extrato);
      } else if (error) {
        // console.log(error);
        dispatch(uiActions.exibirToastr({ show: true, text: error }));
      }
    });
  };

  return (
    <>
      <Tooltip title="Carregar Extrato Bancário (CSV)">
        <IconButton color="info" onClick={clickOpenHandler}>
          <UploadFile />
        </IconButton>
      </Tooltip>
      <DialogCarregarExtrato
        open={open}
        onClose={closeHandler}
        onAddExtrato={addExtratoHandler}
        isLoading={status === "pending"}
        nomeBanco={contaBancaria.nomeBanco}
        referenciaId={contaBancaria.referenciaId}
        extratoId={contaBancaria.extratoId}
      />
    </>
  );
};

export default CarregarExtrato;
