import { AccountBalanceWallet } from '@mui/icons-material'
import { Icon, Tooltip } from '@mui/material'
import { Link } from 'react-router-dom'

const VisualizarExtrato = ({ referenciaId }: any) => {
  return (
    <Tooltip title="Visualizar Extrato">
      <Link className="link" to={`/referencias/${referenciaId}/extrato`}>
        <Icon color="primary">
          <AccountBalanceWallet />
        </Icon>
      </Link>
    </Tooltip>
  );
};

export default VisualizarExtrato;
