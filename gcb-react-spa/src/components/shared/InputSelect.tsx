import { MenuItem, TextField } from '@mui/material'
import { Control, Controller } from 'react-hook-form'

interface CustomInputProps {
  name: string;
  control?: Control<any, any>;
  rules?: any;

  label?: string;
  margin?: "dense" | "normal" | "none";
  variant?: "filled" | "standard" | "filled" | "outlined";

  currencyFormat?: boolean;

  items: SelectItem[];
}

interface SelectItem {
  label: string;
  value: string;
}

const InputSelect = (props: CustomInputProps) => {
  const { items } = props;

  const selectItems = items.map((tc) => (
    <MenuItem key={tc.value} value={tc.value}>
      {tc.label}
    </MenuItem>
  ));

  return (
    <Controller
      name={props.name}
      control={props.control}
      rules={props.rules}
      render={({ field, fieldState }) => (
        <TextField
          {...field}
          select
          fullWidth
          error={!!fieldState.error}
          label={props.label}
          margin={props.margin || "dense"}
          variant={props.variant || "filled"}
        >
          {selectItems}
        </TextField>
      )}
    />
  );
};

export default InputSelect;
