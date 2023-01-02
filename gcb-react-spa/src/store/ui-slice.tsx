import { createSlice } from '@reduxjs/toolkit'

const OD_ITEM_KEY = "ocultarDinheiro";

const loadState = () => {
  try {
    const isVisible = localStorage.getItem(OD_ITEM_KEY);
    if (isVisible === null) {
      return { ocultarDinheiro: false };
    }
    return { ocultarDinheiro: true };
  } catch (err) {
    return { ocultarDinheiro: false };
  }
};

const uiSlice = createSlice({
  name: "ui",
  initialState: loadState(),
  reducers: {
    alternarVisibilidadeDinheiro(state) {
      state.ocultarDinheiro = !state.ocultarDinheiro;
    },
  },
});

export const uiActions = uiSlice.actions;
export const uiReducer = uiSlice.reducer;

export const uiMiddleware = (store: any) => (next: any) => (action: any) => {
  if (uiActions.alternarVisibilidadeDinheiro.match(action)) {
    const isVisible = localStorage.getItem(OD_ITEM_KEY);

    if (isVisible) {
      localStorage.removeItem(OD_ITEM_KEY);
    } else {
      localStorage.setItem(OD_ITEM_KEY, "true");
    }
  }

  return next(action);
};
