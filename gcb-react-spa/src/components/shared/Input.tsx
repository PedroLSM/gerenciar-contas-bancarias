import { TextField } from '@mui/material'
import { Control, Controller } from 'react-hook-form'

import { NumberFormatCustom } from '../../lib/number-format'

interface CustomInputProps {
  name: string;
  control?: Control<any, any>;
  rules?: any;

  label?: string;
  margin?: "dense" | "normal" | "none";
  variant?: "filled" | "standard" | "filled" | "outlined";

  currencyFormat?: boolean;
}

const Input = (props: CustomInputProps) => {
  return (
    <Controller
      name={props.name}
      control={props.control}
      rules={props.rules}
      render={({ field, fieldState }) => (
        <TextField
          {...field}
          fullWidth
          error={!!fieldState.error}
          label={props.label}
          margin={props.margin || "dense"}
          variant={props.variant || "filled"}
          InputProps={
            props.currencyFormat
              ? { inputComponent: NumberFormatCustom as any }
              : undefined
          }
        />
      )}
    />
  );
};

export default Input;
