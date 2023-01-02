import './index.css'

import ReactDOM from 'react-dom/client'
import { createTheme, ThemeProvider } from '@mui/material'
import { Provider } from 'react-redux'

import App from './App'
import store from './store'

const theme = createTheme();

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

root.render(
  <ThemeProvider theme={theme}>
    <Provider store={store}>
      <App />
    </Provider>
  </ThemeProvider>
);
