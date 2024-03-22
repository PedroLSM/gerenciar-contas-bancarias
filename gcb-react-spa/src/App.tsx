import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
  Navigate,
} from "react-router-dom";

import RootLayout from "./components/layout/RootLayout";
import ErrorPage from "./pages/ErrorPage";
import ExtratoPage from "./pages/ExtratoPage";
import ReferenciasPage from "./pages/ReferenciasPage";
import EmprestimosPage from "./pages/EmprestimosPage";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route element={<RootLayout />} errorElement={<ErrorPage />}>
      <Route path="/" element={<Navigate replace to="/referencias" />} />
      <Route path="/referencias" element={<ReferenciasPage />} />
      <Route
        path="/referencias/:referenciaId/extrato"
        element={<ExtratoPage />}
      />
      <Route path="/emprestimos" element={<EmprestimosPage />} />
    </Route>
  )
);

const App = () => {
  return <RouterProvider router={router} />;
};

export default App;
