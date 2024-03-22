import { Visibility, VisibilityOff } from '@mui/icons-material'
import { AppBar, Box, IconButton, Toolbar, Typography } from '@mui/material'
import { useDispatch, useSelector } from 'react-redux'
import { Link } from 'react-router-dom'

import { uiActions } from '../../store/ui-slice'
import Logo from '../../assets/logo_2.png';

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
          <Link className='link-img' to="/">
            <img
              src={Logo}
              alt="GCB"
              width={75}
            />
          </Link>

          {/* <Typography variant="h6" component="div" sx={{ flexGrow: 0, marginLeft: 2 }}>
            <Link className="link" to="/">
              Referências
            </Link>
          </Typography> */}
          <Typography variant="h6" component="div" sx={{ flexGrow: 1, marginLeft: 2 }}>
            <Link className="link" to="/emprestimos">
              Empréstimos
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
