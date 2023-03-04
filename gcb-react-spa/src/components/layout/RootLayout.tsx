import { CssBaseline } from "@mui/material";
import { Outlet } from "react-router-dom";
import Toastr from "../shared/Toastr";
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

      <Toastr />
    </>
  );
};

export default RootLayout;
