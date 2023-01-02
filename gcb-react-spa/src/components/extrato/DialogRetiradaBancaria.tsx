import { useEffect } from 'react'
import { Box, Button, Dialog, DialogActions, DialogContent, DialogTitle } from '@mui/material'
import { useForm, useWatch } from 'react-hook-form'

import useHttp from '../../hooks/use-http'
import Input from '../shared/Input'
import InputSelect from '../shared/InputSelect'
import LoadingSpinner from '../UI/LoadingSpinner'
import { obterContasTransferencia } from '../../lib/api'
import { ContaTransferencia } from '../../models/Extrato'

const DialogRetiradaBancaria = (props: any) => {
  const {
    nomeBanco,
    referenciaId,
    extratoId,
    onClose,
    onAddRetirada,
    open,
    isLoading,
  } = props;

  const tipoRetiradas = [
    { value: "Retirada", label: "Retirada" },
    { value: "Transferencia", label: "Transferência" },
  ];

  const { control, handleSubmit, reset } = useForm({
    mode: "onBlur",
    defaultValues: {
      tipoRetirada: "Retirada",
      extratoTransferenciaId: "",
      descricao: "",
      valor: 0,
    },
  });

  const {
    sendRequest,
    status,
    error,
    data: contas,
  } = useHttp(obterContasTransferencia);

  const tipoTransferenciaValue = useWatch({ control, name: "tipoRetirada" });

  useEffect(() => {
    if (!open) {
      reset();
    }
  }, [open, reset]);

  useEffect(() => {
    if (tipoTransferenciaValue === "Transferencia") {
      sendRequest({ referenciaId, extratoId });
    }
  }, [extratoId, referenciaId, sendRequest, tipoTransferenciaValue]);

  let contasTransferencia: any[] = [];

  if (status === "pending") {
    contasTransferencia = [{ label: "Carregando...", value: "" }];
  } else if (status === "completed") {
    if (error) {
      contasTransferencia = [
        { label: "Falha ao obter as informações", value: "" },
      ];
    } else if (contas) {
      contasTransferencia = [{ label: "", value: "" }];

      const ctMapped = contas.map((ct: ContaTransferencia) => ({
        label: ct.nomeBanco,
        value: ct.extratoId,
      }));

      contasTransferencia.push(...ctMapped);
    }
  }

  return (
    <>
      <Dialog open={open} keepMounted maxWidth="md" fullWidth={true}>
        <Box component="form" autoComplete="off">
          {isLoading && <LoadingSpinner fullScreen={true} />}

          <DialogTitle>Retirar - {nomeBanco}</DialogTitle>

          <DialogContent>
            <InputSelect
              name="tipoRetirada"
              label="Tipo de Retirada"
              control={control}
              rules={{ required: true }}
              items={tipoRetiradas}
            />

            {tipoTransferenciaValue === "Transferencia" && (
              <InputSelect
                name="extratoTransferenciaId"
                label="Transferir Para Conta"
                control={control}
                rules={{ required: true }}
                items={contasTransferencia}
              />
            )}

            <Input
              name="descricao"
              label="Descrição"
              control={control}
              rules={{ required: true }}
            />

            <Input
              name="valor"
              label="Valor"
              control={control}
              rules={{ required: true, min: 0.01 }}
              currencyFormat={true}
            />
          </DialogContent>

          <Box paddingX={2} paddingBottom={1.5}>
            <DialogActions>
              <Button fullWidth variant="outlined" onClick={onClose}>
                Retornar
              </Button>
              <Button
                fullWidth
                type="submit"
                variant="contained"
                onClick={handleSubmit(onAddRetirada)}
              >
                Adicionar Retirada
              </Button>
            </DialogActions>
          </Box>
        </Box>
      </Dialog>
    </>
  );
};

export default DialogRetiradaBancaria;
