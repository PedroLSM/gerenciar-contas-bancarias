import { Divider, Typography } from "@mui/material";

const Title = ({ text, hiddenDivider }: any) => {
  return (
    <>
      <Typography my={1} variant="h6">
        {text}
      </Typography>
      {!hiddenDivider && <Divider sx={{ marginBottom: 2 }} />}
    </>
  );
};

export default Title;
