import { useEffect, useState } from 'react'
import { Skeleton, Typography } from '@mui/material'
import { useSelector } from 'react-redux'

import { currencyColorName, numberFormat } from '../../lib/number-format'

const VisibleCurrentText = (props: any) => {
  const ocultarDinheiro = useSelector((state: any) => state.ui.ocultarDinheiro);
  const color = props.color || currencyColorName(props.currency);

  const [ocultar, setOcultar] = useState<boolean>(false);

  useEffect(() => {
    setOcultar(ocultarDinheiro);
  }, [ocultarDinheiro]);

  const alternarHandler = () => {
    setOcultar((prevState) => !prevState);
  };

  const showSkeleton = ocultar || (ocultar && ocultarDinheiro);

  return (
    <Typography
      onClick={alternarHandler}
      fontWeight="bold"
      variant="subtitle2"
      color={color}
      sx={{ cursor: "pointer" }}
      {...props}
    >
      {showSkeleton ? (
        <Skeleton />
      ) : (
        numberFormat(props.currency, props.signDisplay)
      )}
    </Typography>
  );
};

export default VisibleCurrentText;
