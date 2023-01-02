export const validateRequired = (
  controlName: string,
  value: any,
  errors: any
) => {
  let result = true;

  if (!value || (typeof value === "string" && !value.trim())) {
    errors[controlName] = "Campo Obrigátorio";
    result = false;
  }

  return result;
};
