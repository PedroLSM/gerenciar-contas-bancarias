import { useEffect } from 'react'
import { useForm } from 'react-hook-form'
import DialogMain from '../shared/DialogMain'
import Input from '../shared/Input'

const DialogPagamento = (props: any) => {
    const { devedor, open, onClose, onAddPagamento, isLoading } = props;

    const { control, handleSubmit, reset } = useForm({
        mode: "onBlur",
        defaultValues: {
            dataPagamento: null,
            valorPago: 0,
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
            title={`Pagamento - ${devedor}`}
            onClose={onClose}
            btnConfirmText="Adicionar Pagamento"
            onConfirm={handleSubmit(onAddPagamento)}
        >
            <Input
                name="dataPagamento"
                label="Data do Pagamento"
                type="date"
                control={control}
                rules={{ required: false }}
            />

            <Input
                name="valorPago"
                label="Valor Pago"
                control={control}
                rules={{ required: true, min: 0.01 }}
                currencyFormat={true}
            />
        </DialogMain>
    );
};

export default DialogPagamento;
