import { Box, CircularProgress, CircularProgressProps, colors, Typography } from '@mui/material'

const CircularProgressWithLabel = (
  props: CircularProgressProps & { value: number }
) => {
  return (
    <Box sx={{ position: "relative", display: "inline-flex" }}>
      <CircularProgress
        size={100}
        thickness={4}
        variant="determinate"
        sx={{ color: colors.grey[200] }}
        value={100}
      />
      <CircularProgress
        size={100}
        thickness={4}
        variant="determinate"
        sx={{ position: "absolute" }}
        {...props}
      />
      <Box
        sx={{
          top: 0,
          left: 0,
          bottom: 0,
          right: 0,
          position: "absolute",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <Typography variant="h5" component="div" color="text.secondary">
          {`${Math.round(props.value)}%`}
        </Typography>
      </Box>
    </Box>
  );
};

export default CircularProgressWithLabel;
