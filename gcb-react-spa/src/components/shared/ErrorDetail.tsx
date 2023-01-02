import { Error } from "@mui/icons-material";
import { Icon, Typography } from "@mui/material";

const ErrorDetail = (props: any) => {
  return (
    <div
      style={{
        display: "flex",
        alignItems: "center",
        flexWrap: "wrap",
      }}
    >
      <Icon color="warning">
        <Error />
      </Icon>
      <Typography marginLeft={1}>{props.error}</Typography>
    </div>
  );
};

export default ErrorDetail;
