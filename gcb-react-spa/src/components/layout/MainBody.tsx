import { Box, Paper } from '@mui/material'

import classes from './MainBody.module.css'

const MainBody = (props: any) => {
  return (
    <Box
      sx={{
        bgcolor: "#d0d0d0",
        height: "calc(100vh - 64px)",
        padding: "1rem 1rem",
      }}
    >
      <Paper className={classes["paper-container"]} elevation={3}>
        {props.children}
      </Paper>
    </Box>
  );
};

export default MainBody;
