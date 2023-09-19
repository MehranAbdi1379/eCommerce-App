import {
  Route,
  RouterProvider,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import RootLayout from "./layouts/Global/RootLayout";
import MainPage from "./pages/Global/MainPage";
import EmailVerificationSentPage from "./pages/Global/EmailVerificationSentPage";
import EmailVerifiedPage from "./pages/Global/EmailVerifiedPage";
import SignUpLogInPage from "./pages/Global/SignUpLogInPage";
import PasswordResetRequestPage from "./pages/Global/PasswordResetRequestPage";
import PasswordResetPage from "./pages/Global/PasswordResetPage";
import AdminSignInPage from "./pages/Admin/AdminSignInPage";
import AdminRootLayout from "./layouts/Admin/AdminRootLayout";
import AdminMainPage from "./pages/Admin/AdminMainPage";
import AdminCategoryPage from "./pages/Admin/Category/AdminCategoryPage";
import AdminCategoryCreatePage from "./pages/Admin/Category/AdminCategoryCreatePage";

function App() {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route>
        <Route element={<RootLayout />}>
          <Route index element={<MainPage />}></Route>
          <Route path="sign" element={<SignUpLogInPage />}></Route>
          <Route
            path="email-verification-sent"
            element={<EmailVerificationSentPage />}
          ></Route>
          <Route path="email-verified" element={<EmailVerifiedPage />}></Route>
          <Route
            path="password-reset-request"
            element={<PasswordResetRequestPage />}
          ></Route>
          <Route path="password-reset" element={<PasswordResetPage />}></Route>
        </Route>
        <Route path="admin" element={<AdminRootLayout />}>
          <Route index element={<AdminSignInPage />}></Route>
          <Route path="logged-in" element={<AdminMainPage />}></Route>
          <Route path="category">
            <Route index element={<AdminCategoryPage />}></Route>
            <Route path="create" element={<AdminCategoryCreatePage />}></Route>
          </Route>
        </Route>
      </Route>
    )
  );

  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
