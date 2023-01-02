import { Menu, Visibility, VisibilityOff } from '@mui/icons-material'
import { AppBar, Box, IconButton, Toolbar, Typography } from '@mui/material'
import { useDispatch, useSelector } from 'react-redux'
import { Link } from 'react-router-dom'

import { uiActions } from '../../store/ui-slice'

const MainHeader = () => {
  const ocultarDinheiro = useSelector((state: any) => state.ui.ocultarDinheiro);
  const dispatch = useDispatch();

  const alterarHandler = () => {
    dispatch(uiActions.alternarVisibilidadeDinheiro());
  };

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <Menu />
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            <Link className="link" to="/">
              Gerenciar Contas Bancarias
            </Link>
          </Typography>
          <IconButton
            onClick={alterarHandler}
            size="large"
            edge="end"
            color="inherit"
            aria-label="ocultar dinheiro"
            sx={{ mr: 2 }}
          >
            {ocultarDinheiro ? <Visibility /> : <VisibilityOff />}
          </IconButton>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default MainHeader;
