import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material'

import usePaginator from '../../hooks/use-paginator'
import Paginator from '../shared/Paginator'
import VisibleCurrentText from '../UI/VisibleCurrentText'
import VisualizarExtrato from './VisualizarExtrato'
import { Mes, Referencia } from '../../models/Referencia'

const ListaReferencias = (props: any) => {
  const paginator = usePaginator<Mes>({ rowsPerPageOptions: [12, 24, 36] });
  const { referencia }: { referencia: Referencia } = props;

  return (
    <>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} size="small">
          <TableHead>
            <TableRow>
              <TableCell>Ano Referência</TableCell>
              <TableCell>Mês Referência</TableCell>
              <TableCell>Total Retirado</TableCell>
              <TableCell>Total Depositado </TableCell>
              <TableCell>Saldo</TableCell>
              <TableCell>Diferência com Saldo Anterior</TableCell>
              <TableCell align="center"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {paginator.slice(referencia.meses).map((mes) => {
              return (
                <TableRow
                  key={mes.id}
                  sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {mes.anoReferencia}
                  </TableCell>
                  <TableCell>{mes.mesReferencia}</TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={mes.totalRetirado} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={mes.totalDepositado} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText currency={mes.saldo} />
                  </TableCell>
                  <TableCell>
                    <VisibleCurrentText
                      signDisplay="exceptZero"
                      currency={mes.diferencaSaldoAnterior}
                    />
                  </TableCell>
                  <TableCell align="center">
                    <VisualizarExtrato referenciaId={mes.id} />
                  </TableCell>
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
      <Paginator {...paginator} count={referencia.meses.length} />
    </>
  );
};

export default ListaReferencias;
