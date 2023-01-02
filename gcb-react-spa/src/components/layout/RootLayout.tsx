import { CssBaseline } from "@mui/material";
import { Outlet } from "react-router-dom";
import MainBody from "./MainBody";
import MainHeader from "./MainHeader";

const RootLayout = () => {
  return (
    <>
      <CssBaseline />
      <MainHeader />
      <MainBody>
        <Outlet />
      </MainBody>
    </>
  );
};

export default RootLayout;
