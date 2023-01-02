import { FormControl, InputLabel, MenuItem, Select, SelectChangeEvent } from '@mui/material'
import { useState } from 'react'

import { Referencia } from '../../models/Referencia'

const SelecionarAnoReferencia = (props: any) => {
  const {
    referencias,
    onReferenciaSelecionada,
  }: {
    referencias: Referencia[];
    onReferenciaSelecionada: (data: Referencia) => {};
  } = props;

  const [referencia, setReferencia] = useState("0");

  const handleChange = (event: SelectChangeEvent) => {
    const refIndex = event.target.value;

    setReferencia(refIndex);

    const referenciaSelecionada = referencias[+refIndex] || referencia[0];

    if (onReferenciaSelecionada) {
      onReferenciaSelecionada(referenciaSelecionada);
    }
  };

  const menuItems = referencias.map((ref, index) => (
    <MenuItem key={ref.anoReferencia} value={index}>
      {ref.anoReferencia || "Todos"}
    </MenuItem>
  ));

  return (
    <FormControl variant="filled" fullWidth>
      <InputLabel id="selecionar-ano-referencia">
        Selecione o ano de referência
      </InputLabel>
      <Select
        labelId="selecionar-ano-referencia"
        id="ano-referencia"
        value={referencia}
        label="Selecione o ano de referência"
        onChange={handleChange}
      >
        {menuItems}
      </Select>
    </FormControl>
  );
};

export default SelecionarAnoReferencia;
