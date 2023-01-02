import { CircularProgress } from '@mui/material'

const LoadingSpinner = (props: any) => {
  return props.fullScreen ? (
    <div className="loading">
      <CircularProgress />
    </div>
  ) : (
    <CircularProgress />
  );
};

export default LoadingSpinner;
