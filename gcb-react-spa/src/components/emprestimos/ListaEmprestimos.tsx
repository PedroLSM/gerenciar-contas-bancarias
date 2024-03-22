import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import usePaginator from "../../hooks/use-paginator";
import { Emprestimo } from "../../models/Emprestimo";
import { format } from "date-fns";
import VisibleCurrentText from "../UI/VisibleCurrentText";
import Paginator from "../shared/Paginator";
import { currencyColorNameInvert } from "../../lib/number-format";
import Pagamento from "./Pagamento";
import { useState } from "react";
import Pagamentos from "./Pagamentos";

const ListaEmprestimos = (props: any) => {
  const paginator = usePaginator<Emprestimo>({ rowsPerPageOptions: [12, 24, 36] });
  const { emprestimos: emprestimosData }: { emprestimos: Emprestimo[] } = props;

  const [emprestimos, setEmprestimos] = useState(emprestimosData || []);

  const atualizarEmprestimoHandler = (emprestimo: Emprestimo) => {
    console.log("Update", emprestimo);

    if (emprestimo) {
      setEmprestimos((current) =>
        current.map((emp) => {
          if (emprestimo.id === emp.id) {
            return {
              ...emp,
              valorPago: emprestimo.valorPago,
              valorDevendo: emprestimo.valorDevendo,
            } as Emprestimo;
          }

          return emp;
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
              <TableCell>Data Empréstimo</TableCell>
              <TableCell>Devedor</TableCell>
              <TableCell>Empréstimo</TableCell>
              <TableCell>A Ser Pago</TableCell>
              <TableCell>Devendo</TableCell>
              <TableCell>Pago</TableCell>
              <TableCell align="center"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {paginator.slice(emprestimos).map((emp) => {
              const color = currencyColorNameInvert(emp.valorDevendo);

              return (
                <TableRow
                  key={emp.id}
                  sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {format(new Date(emp.dataEmprestimo), "dd/MM/yyyy")}
                  </TableCell>
                  <TableCell>{emp.devedor}</TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={emp.valorEmprestimo} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={emp.valorPrevisto} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText color={color} currency={emp.valorDevendo} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={emp.valorPago} />
                  </TableCell>
                  <TableCell align="center">
                    <Pagamento
                      emprestimo={emp}
                      onPagamento={atualizarEmprestimoHandler}
                    />
                    <Pagamentos emprestimo={emp} />
                  </TableCell>
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
      <Paginator {...paginator} count={emprestimos.length} />
    </>
  );
};

export default ListaEmprestimos;
