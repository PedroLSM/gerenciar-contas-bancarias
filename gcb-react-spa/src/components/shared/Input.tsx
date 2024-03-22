import { TextField } from "@mui/material";
import { Control, Controller } from "react-hook-form";

import { NumberFormatCustom } from "../../lib/number-format";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { ptBR } from "date-fns/locale";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';

import 'moment/locale/pt-br';
import moment from 'moment';

interface CustomInputProps {
  name: string;
  control?: Control<any, any>;
  rules?: any;

  label?: string;
  type?: string;
  margin?: "dense" | "normal" | "none";
  variant?: "filled" | "standard" | "filled" | "outlined";

  currencyFormat?: boolean;
}

const Input = (props: CustomInputProps) => {
  const fsProp: any = {};

  if (props.type === "file") {
    fsProp["focused"] = true;
  }

  if (props.type === "date") {
    moment.locale('pt-br');
  }

  return (
    <Controller
      name={props.name}
      control={props.control}
      rules={props.rules}
      render={({ field, fieldState }) => {
        if (props.type === 'date') {
          return (
            <LocalizationProvider adapterLocale={ptBR} dateAdapter={AdapterDateFns}>
              <DatePicker
                label={props.label}
                fullWidth
                error={!!fieldState.error}
                margin={props.margin || "dense"}
                variant={props.variant || "filled"}
                inputFormat="dd/MM/yyyy"
                {...field}
                {...fsProp}
                renderInput={(params: any) =>
                  <TextField
                    {...params}
                    fullWidth
                    error={!!fieldState.error}
                    margin={props.margin || "dense"}
                    variant={props.variant || "filled"}
                  />}
              />
            </LocalizationProvider>
          )
        }

        if (props.type !== "file") {
          return (
            <TextField
              {...field}
              {...fsProp}
              fullWidth
              type={props.type || "text"}
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
          );
        }
        return (
          <TextField
            {...field}
            {...fsProp}
            fullWidth
            type={props.type || "text"}
            error={!!fieldState.error}
            label={props.label}
            margin={props.margin || "dense"}
            variant={props.variant || "filled"}
            value={field.value?.filename}
            onChange={(event) => {
              return field.onChange((event.target as any)?.files[0]);
            }}
            InputProps={
              props.currencyFormat
                ? { inputComponent: NumberFormatCustom as any }
                : undefined
            }
          />
        );
      }}
    />
  );
};

export default Input;
