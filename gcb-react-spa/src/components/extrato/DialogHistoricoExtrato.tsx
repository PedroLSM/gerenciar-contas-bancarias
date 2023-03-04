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
import { obterHistoricoExtrato } from "../../lib/api";
import { HistoricoExtrato } from "../../models/Extrato";
import { currencyFormatByOperation } from "../../lib/number-format";

const DialogHistoricoExtrato = (props: any) => {
  const { open, nomeBanco, extratoId } = props;

  const paginator = usePaginator<HistoricoExtrato>({
    rowsPerPageOptions: [15, 30, 50],
  });

  const {
    sendRequest,
    status,
    data: historico,
  } = useHttp(obterHistoricoExtrato, true);

  useEffect(() => {
    if (open) {
      sendRequest(extratoId);
    }
  }, [open, sendRequest, extratoId]);

  const closeHandler = () => {
    props.onClose();
  };

  return (
    <DialogMain
      open={open}
      component="section"
      isLoading={status === "pending"}
      title={`Histórico - ${nomeBanco}`}
      onClose={closeHandler}
      maxWidth="lg"
    >
      <TableContainer component={Paper}>
        <Table size="small">
          <TableHead>
            <TableRow>
              <TableCell>Data</TableCell>
              <TableCell>Histórico</TableCell>
              <TableCell>Valor</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {paginator.slice(historico).map((his) => {
              const { currency, color, fontWeight } = currencyFormatByOperation(
                his.valor,
                his.tipoOperacao
              );

              return (
                <TableRow
                  key={his.operacaoId}
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
                      fontWeight={fontWeight}
                    >
                      {format(new Date(his.dataRegistro), "dd/MM")} -{" "}
                      {format(new Date(his.dataRegistro), "HH:mm")}
                    </Typography>
                  </TableCell>
                  <TableCell component="th" scope="row">
                    <Typography
                      component="span"
                      variant="subtitle2"
                      fontWeight={fontWeight}
                    >
                      {his.descricao}
                    </Typography>
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText color={color} currency={currency} />
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

export default DialogHistoricoExtrato;
