import {
  Route,
  RouterProvider,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import MainPage from "./pages/MainPage";

function App() {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route>
        <Route index element={<MainPage />} />
      </Route>
    )
  );

  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
