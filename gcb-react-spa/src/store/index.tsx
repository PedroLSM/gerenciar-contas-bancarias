import { configureStore } from '@reduxjs/toolkit'

import { uiMiddleware, uiReducer } from './ui-slice'

const store = configureStore({
  reducer: {
    ui: uiReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(uiMiddleware),
});

export default store;
