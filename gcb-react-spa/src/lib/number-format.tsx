import { forwardRef } from 'react'
import { NumericFormat } from 'react-number-format'

export const numberFormat = (
  value: number,
  signDisplay: "auto" | "never" | "always" | "exceptZero" = "auto"
) =>
  `R$ ${new Intl.NumberFormat("pt-BR", {
    minimumFractionDigits: 2,
    signDisplay: signDisplay || "auto",
  }).format(value)}`;

export const currencyColorName = (value: number) => {
  if (value === 0) {
    return "warning.main";
  }

  return value > 0 ? "success.main" : "error.main";
};

export const progressColorName = (value: number) => {
  if (value < 50) {
    return "error";
  }

  return value >= 70 ? "success" : "warning";
};

export const currencyFormatByOperation = (value: number, operation: string) => {
  if (operation === "Saldo") {
    return {
      fontWeight: "bold",
      currency: value,
      color: currencyColorName(value),
    };
  }

  return operation === "Deposito"
    ? { fontWeight: "normal", currency: value, color: "success.main" }
    : { fontWeight: "normal", currency: -value, color: "error.main" };
};

interface CustomProps {
  onChange: (event: { target: { name: string; value: string } }) => void;
  name: string;
}

export const NumberFormatCustom = forwardRef<any, CustomProps>(
  function NumberFormatCustom(props, ref) {
    const { onChange, ...other } = props;

    return (
      <NumericFormat
        {...other}
        getInputRef={ref}
        onValueChange={(values: any) => {
          onChange({
            target: {
              name: props.name,

              value: values.value,
            },
          });
        }}
        valueIsNumericString
        thousandSeparator="."
        decimalSeparator=","
        decimalScale={2}
        prefix="R$"
      />
    );
  }
);
