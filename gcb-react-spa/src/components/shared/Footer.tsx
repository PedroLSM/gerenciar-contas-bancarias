import { Button } from '@mui/material'
import { Box } from '@mui/system'
import { useNavigate } from 'react-router-dom'

const Footer = (props: any) => {
  const navigate = useNavigate();

  const backHandler = () => {
    navigate(props.to);
  };

  return (
    <Box
      component="footer"
      sx={{
        backgroundColor: "rgba(0, 0, 0, 0.06)",
        position: "absolute",
        bottom: "1rem",
        right: "1rem",
        left: "1rem",
      }}
    >
      <Button
        sx={{ height: 56, width: 100 }}
        variant="text"
        onClick={backHandler}
      >
        Voltar
      </Button>
    </Box>
  );
};

export default Footer;
