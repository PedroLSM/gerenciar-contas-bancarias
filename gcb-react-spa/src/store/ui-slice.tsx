import { createSlice, PayloadAction } from "@reduxjs/toolkit";

const OD_ITEM_KEY = "ocultarDinheiro";

const loadState = () => {
  try {
    const isVisible = localStorage.getItem(OD_ITEM_KEY);

    if (isVisible === null) {
      return { ocultarDinheiro: false, exibirToastr: { show: false } };
    }

    return { ocultarDinheiro: true, exibirToastr: { show: false } };
  } catch (err) {
    return { ocultarDinheiro: false, exibirToastr: { show: false } };
  }
};

const uiSlice = createSlice({
  name: "ui",
  initialState: loadState(),
  reducers: {
    alternarVisibilidadeDinheiro(state) {
      state.ocultarDinheiro = !state.ocultarDinheiro;
    },
    exibirToastr(
      state,
      action: PayloadAction<{ show: boolean; text?: string }>
    ) {
      state.exibirToastr = action.payload;
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
