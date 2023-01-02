import { Box, Stack, Typography } from '@mui/material'

import CircularProgressWithLabel from '../UI/CircularProgressWithLabel'
import VisibleCurrentText from '../UI/VisibleCurrentText'
import { progressColorName } from '../../lib/number-format'
import { Referencia } from '../../models/Referencia'

const Receita = (props: any) => {
  const { referencia }: { referencia: Referencia } = props;

  const mesAtual = referencia.meses[0];

  const progress =
    (mesAtual.saldo / (mesAtual.saldo + mesAtual.totalRetirado)) * 100;

  const progressColor = progressColorName(progress);

  return (
    <Stack direction="row" spacing={2} alignItems="center">
      <CircularProgressWithLabel
        variant="determinate"
        color={progressColor}
        value={progress}
      />
      <Box>
        <VisibleCurrentText
          variant="h5"
          component="h5"
          fontWeight={900}
          color="success.main"
          currency={mesAtual.saldo}
        />

        <Typography variant="caption" component="span" color="text.secondary">
          Total de Receitas <br />
          {mesAtual.anoReferencia} /{" "}
          {mesAtual.mesReferencia.substring(0, 3).toUpperCase()}
        </Typography>
      </Box>
    </Stack>
  );
};

export default Receita;
