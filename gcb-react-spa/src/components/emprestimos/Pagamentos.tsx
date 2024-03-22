import { ReceiptLong } from '@mui/icons-material'
import { IconButton, Tooltip } from '@mui/material'
import { useState } from 'react'
import { Emprestimo } from '../../models/Emprestimo';
import DialogHistoricoPagamento from './DialogHistoricoPagamento';

const Pagamentos = (props: any) => {
    const { emprestimo }: { emprestimo: Emprestimo } = props;

    const [open, setOpen] = useState(false);

    const clickOpenHandler = () => {
        setOpen(true);
    };

    const closeHandler = () => {
        setOpen(false);
    };

    return (
        <>
            <Tooltip title="Pagamentos">
                <IconButton color="default" onClick={clickOpenHandler}>
                    <ReceiptLong />
                </IconButton>
            </Tooltip>
            <DialogHistoricoPagamento
                open={open}
                onClose={closeHandler}
                devedor={emprestimo.devedor}
                emprestimoId={emprestimo.id}
            />
        </>
    );
};

export default Pagamentos;
