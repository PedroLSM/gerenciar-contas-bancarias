import { useEffect } from 'react'
import { Box, Button, Dialog, DialogActions, DialogContent, DialogTitle } from '@mui/material'
import { useForm } from 'react-hook-form'

import Input from '../shared/Input'
import LoadingSpinner from '../UI/LoadingSpinner'

const DialogAdicionarEmprestimo = (props: any) => {
  const { open, onClose, onAddEmprestimo, isLoading } = props;

  const { control, handleSubmit, reset } = useForm({
    mode: "onBlur",
    defaultValues: {
      devedor: "",
      dataEmprestimo: "",
      valorEmprestimo: 0,
      valorPrevisto: null,
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

          <DialogTitle>Adicionar Empréstimo</DialogTitle>

          <DialogContent>
            <Input
              name="dataEmprestimo"
              label="Data do Empréstimo"
              type="date"
              control={control}
              rules={{ required: false }}
            />

            <Input
              name="devedor"
              label="Devedor"
              control={control}
              rules={{ required: true }}
            />

            <Input
              name="valorEmprestimo"
              label="Valor Empréstimo"
              control={control}
              rules={{ required: true }}
              currencyFormat={true}
            />

            <Input
              name="valorPrevisto"
              label="Valor A Ser Pago"
              control={control}
              rules={{ required: false }}
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
                onClick={handleSubmit(onAddEmprestimo)}
              >
                Adicionar Empréstimo
              </Button>
            </DialogActions>
          </Box>
        </Box>
      </Dialog>
    </>
  );
};

export default DialogAdicionarEmprestimo;
