import { useState } from "react";
import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";

import usePaginator from "../../hooks/use-paginator";
import Paginator from "../shared/Paginator";
import VisibleCurrentText from "../UI/VisibleCurrentText";
import Depositar from "./Depositar";
import Historico from "./Historico";
import Retirar from "./Retirar";
import { Extrato } from "../../models/Extrato";
import CarregarExtrato from "./CarregarExtrato";

const ListaExtrato = (props: any) => {
  const paginator = usePaginator<Extrato>({ rowsPerPageOptions: [15, 30, 50] });

  const { extrato: extratoData }: { extrato: Extrato[] } = props;

  const [extrato, setExtrato] = useState(extratoData || []);

  const atualizarContaHandler = (conta: Extrato) => {
    console.log("Update", conta);

    if (conta) {
      setExtrato((current) =>
        current.map((ext) => {
          if (conta.extratoId === ext.extratoId) {
            return {
              ...ext,
              saldo: conta.saldo,
              totalDepositado: conta.totalDepositado,
              totalRetirado: conta.totalRetirado,
            } as Extrato;
          }

          return ext;
        })
      );
    }
  };

  return (
    <>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} size="small">
          <TableHead>
            <TableRow>
              <TableCell>Nome do Banco</TableCell>
              <TableCell>Total Retirado</TableCell>
              <TableCell>Total Depositado</TableCell>
              <TableCell>Saldo</TableCell>
              <TableCell>Situação</TableCell>
              <TableCell align="center"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {paginator.slice(extrato).map((ext) => {
              return (
                <TableRow
                  key={ext.extratoId}
                  sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {ext.nomeBanco}
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={ext.totalRetirado} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={ext.totalDepositado} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={ext.saldo} />
                  </TableCell>
                  <TableCell component="th" scope="row">
                    {ext.ativa ? "Ativa" : "Inativa"}
                  </TableCell>
                  <TableCell align="center">
                    <Depositar
                      contaBancaria={ext}
                      onDepositar={atualizarContaHandler}
                    />
                    <Retirar
                      contaBancaria={ext}
                      onRetirar={atualizarContaHandler}
                    />
                    <CarregarExtrato
                      contaBancaria={ext}
                      onCarregar={atualizarContaHandler}
                    />
                    <Historico contaBancaria={ext} />
                  </TableCell>
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
      <Paginator {...paginator} count={extrato.length} />
    </>
  );
};

export default ListaExtrato;
