import { useEffect } from 'react'
import { useForm } from 'react-hook-form'

import DialogMain from '../shared/DialogMain'
import Input from '../shared/Input'

const DialogDepositoBancario = (props: any) => {
  const { nomeBanco, open, onClose, onAddDeposito, isLoading } = props;

  const { control, handleSubmit, reset } = useForm({
    mode: "onBlur",
    defaultValues: {
      descricao: "",
      valor: 0,
    },
  });

  useEffect(() => {
    if (!open) {
      reset();
    }
  }, [open, reset]);

  return (
    <DialogMain
      open={open}
      isLoading={isLoading}
      title={`Depositar - ${nomeBanco}`}
      onClose={onClose}
      btnConfirmText="Adicionar Depósito"
      onConfirm={handleSubmit(onAddDeposito)}
    >
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
    </DialogMain>
  );
};

export default DialogDepositoBancario;
