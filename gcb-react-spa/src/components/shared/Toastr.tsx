import { Alert, Snackbar } from "@mui/material";
import { useDispatch, useSelector } from "react-redux";
import { uiActions } from "../../store/ui-slice";

const Toastr = () => {
  const exibirToastr = useSelector((state: any) => state.ui.exibirToastr);
  const dispatch = useDispatch();

  const handleClose = (
    event?: React.SyntheticEvent | Event,
    reason?: string
  ) => {
    if (reason === "clickaway") {
      return;
    }

    dispatch(uiActions.exibirToastr({ show: false }));
  };

  return (
    <Snackbar
      open={exibirToastr.show}
      autoHideDuration={6000}
      onClose={handleClose}
      anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
    >
      <Alert onClose={handleClose} severity="warning" sx={{ width: "100%" }}>
        {exibirToastr.text}
      </Alert>
    </Snackbar>
  );
};

export default Toastr;
