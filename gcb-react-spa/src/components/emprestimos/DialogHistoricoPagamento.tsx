import { useEffect } from "react";
import {
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
} from "@mui/material";
import { format } from "date-fns";

import useHttp from "../../hooks/use-http";
import usePaginator from "../../hooks/use-paginator";
import DialogMain from "../shared/DialogMain";
import Paginator from "../shared/Paginator";
import VisibleCurrentText from "../UI/VisibleCurrentText";
import { obterHistoricoPagamento } from "../../lib/api";
import { HistoricoPagamento } from "../../models/Emprestimo";

const DialogHistoricoPagamento = (props: any) => {
    const { open, devedor, emprestimoId } = props;

    const paginator = usePaginator<HistoricoPagamento>({
        rowsPerPageOptions: [15, 30, 50],
    });

    const {
        sendRequest,
        status,
        data: historico,
    } = useHttp(obterHistoricoPagamento, true);

    useEffect(() => {
        if (open) {
            sendRequest(emprestimoId);
        }
    }, [open, sendRequest, emprestimoId]);

    const closeHandler = () => {
        props.onClose();
    };

    return (
        <DialogMain
            open={open}
            component="section"
            isLoading={status === "pending"}
            title={`Pagamentos - ${devedor}`}
            onClose={closeHandler}
            maxWidth="lg"
        >
            <TableContainer component={Paper}>
                <Table size="small">
                    <TableHead>
                        <TableRow>
                            <TableCell>Data</TableCell>
                            <TableCell>Valor</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {paginator.slice(historico).map((his) => {
                            return (
                                <TableRow
                                    key={his.id}
                                    sx={{
                                        "&:last-child td, &:last-child th": {
                                            border: 0,
                                            backgroundColor: "whitesmoke",
                                        },
                                    }}
                                >
                                    <TableCell component="th" scope="row">
                                        <Typography
                                            component="span"
                                            variant="subtitle2"
                                            fontWeight="bold"
                                        >
                                            {format(new Date(his.dataPagamento), "dd/MM/yyyy")}
                                        </Typography>
                                    </TableCell>
                                    <TableCell>
                                        <VisibleCurrentText currency={his.valorPago} />
                                    </TableCell>
                                </TableRow>
                            );
                        })}
                    </TableBody>
                </Table>
            </TableContainer>
            <Paginator {...paginator} count={historico?.length} />
        </DialogMain>
    );
};

export default DialogHistoricoPagamento;
