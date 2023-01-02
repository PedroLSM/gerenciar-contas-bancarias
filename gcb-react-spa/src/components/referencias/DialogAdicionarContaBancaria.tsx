import { useEffect } from 'react'
import { Box, Button, Dialog, DialogActions, DialogContent, DialogTitle } from '@mui/material'
import { useForm } from 'react-hook-form'

import Input from '../shared/Input'
import InputSelect from '../shared/InputSelect'
import LoadingSpinner from '../UI/LoadingSpinner'

const DialogAdicionarContaBancaria = (props: any) => {
  const { open, onClose, onAddContaBancaria, isLoading } = props;

  const tipoContas = [
    { value: "Poupanca", label: "Poupança" },
    { value: "Corrente", label: "Corrente" },
    { value: "PoupancaCorrente", label: "Poupança e Corrente" },
    { value: "Credito", label: "Crédito" },
    { value: "CreditoPoupanca", label: "Crétido e Poupança" },
  ];

  const { control, handleSubmit, reset } = useForm({
    mode: "onBlur",
    defaultValues: {
      nomeBanco: "",
      tipoConta: "Poupanca",
      saldoAtual: 0,
    },
  });

  useEffect(() => {
    if (!open) {
      reset();
    }
  }, [open, reset]);

  return (
    <>
      <Dialog open={open} keepMounted maxWidth="md" fullWidth={true}>
        <Box component="form" autoComplete="off">
          {isLoading && <LoadingSpinner fullScreen={true} />}

          <DialogTitle>Adicionar Conta Bancária</DialogTitle>

          <DialogContent>
            <Input
              name="nomeBanco"
              label="Nome do Banco"
              control={control}
              rules={{ required: true }}
            />

            <InputSelect
              name="tipoConta"
              label="Tipo de Conta"
              control={control}
              rules={{ required: true }}
              items={tipoContas}
            />

            <Input
              name="saldoAtual"
              label="Saldo Atual"
              control={control}
              rules={{ required: true }}
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
                onClick={handleSubmit(onAddContaBancaria)}
              >
                Adicionar Conta
              </Button>
            </DialogActions>
          </Box>
        </Box>
      </Dialog>
    </>
  );
};

export default DialogAdicionarContaBancaria;
