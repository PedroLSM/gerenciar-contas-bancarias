import { AddCard } from "@mui/icons-material";
import { IconButton, Tooltip } from "@mui/material";
import { useState } from "react";

import useHttp from "../../hooks/use-http";
import { adicionarEmprestimoPagamento } from "../../lib/api";
import { useDispatch } from "react-redux";
import { uiActions } from "../../store/ui-slice";
import { Emprestimo } from "../../models/Emprestimo";
import DialogPagamento from "./DialogPagamento";

const Pagamento = (props: any) => {
    const dispatch = useDispatch();

    const { emprestimo }: { emprestimo: Emprestimo } = props;

    const [open, setOpen] = useState(false);

    const { sendRequest, status, error } = useHttp(adicionarEmprestimoPagamento);

    const clickOpenHandler = () => {
        setOpen(true);
    };

    const closeHandler = () => {
        setOpen(false);
    };

    const addPagamentoHandler = (pagamentoForm: any) => {
        const pagamento = { ...pagamentoForm, emprestimoId: emprestimo.id };

        sendRequest(pagamento).then((response: any) => {
            if (response) {
                closeHandler();
                props.onPagamento(response.dados as Emprestimo);
            } else if (error) {
                dispatch(uiActions.exibirToastr({ show: true, text: error }));
            }
        });
    };

    return (
        <>
            <Tooltip title="Adicionar Pagamento">
                <IconButton color="success" onClick={clickOpenHandler}>
                    <AddCard />
                </IconButton>
            </Tooltip>
            <DialogPagamento
                open={open}
                onClose={closeHandler}
                onAddPagamento={addPagamentoHandler}
                isLoading={status === "pending"}
                devedor={emprestimo.devedor}
            />
        </>
    );
};

export default Pagamento;
