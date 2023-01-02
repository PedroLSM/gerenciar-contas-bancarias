import { Button, Dialog, DialogActions, DialogContent, DialogProps, DialogTitle } from '@mui/material'
import { Box, BoxProps } from '@mui/system'

import LoadingSpinner from '../UI/LoadingSpinner'

export interface DialogMainProps {
  isLoading?: boolean;

  title: string;

  btnCloseText?: string;
  onClose: any;

  btnConfirmText?: string;
  onConfirm?: any;
}

const DialogMain = (props: DialogMainProps & DialogProps & BoxProps) => {
  return (
    <Dialog
      open={props.open}
      keepMounted={props.keepMounted && true}
      maxWidth={props.maxWidth || "md"}
      fullWidth={true}
    >
      <Box component={props.component || "form"} autoComplete="off">
        {props.isLoading && <LoadingSpinner fullScreen={true} />}

        <DialogTitle>{props.title}</DialogTitle>

        <DialogContent>{props.children}</DialogContent>

        <Box paddingX={2} paddingBottom={1.5}>
          <DialogActions>
            <Button
              fullWidth
              variant="outlined"
              type="button"
              onClick={props.onClose}
            >
              {props.btnCloseText || "Retornar"}
            </Button>
            {props.btnConfirmText && (
              <Button
                fullWidth
                variant="contained"
                type="submit"
                onClick={props.onConfirm}
              >
                {props.btnConfirmText || "Salvar"}
              </Button>
            )}
          </DialogActions>
        </Box>
      </Box>
    </Dialog>
  );
};

export default DialogMain;
