import { useEffect } from "react";
import { useForm } from "react-hook-form";

import DialogMain from "../shared/DialogMain";
import Input from "../shared/Input";

const DialogCarregarExtrato = (props: any) => {
  const { nomeBanco, open, onClose, onAddExtrato, isLoading } = props;

  const { control, handleSubmit, reset } = useForm({
    mode: "onBlur",
    defaultValues: {
      arquivo: null,
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
      title={`Carregar Extrato CSV - ${nomeBanco}`}
      onClose={onClose}
      btnConfirmText="Carregar Extrato"
      onConfirm={handleSubmit(onAddExtrato)}
    >
      <Input
        name="arquivo"
        label="Arquivo"
        type="file"
        control={control}
        rules={{ required: true }}
      />
    </DialogMain>
  );
};

export default DialogCarregarExtrato;
