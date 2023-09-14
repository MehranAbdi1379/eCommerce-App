import {
  Route,
  RouterProvider,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import RootLayout from "./layouts/RootLayout";
import MainPage from "./pages/Global/MainPage";
import EmailVerificationSentPage from "./pages/Global/EmailVerificationSentPage";
import EmailVerifiedPage from "./pages/Global/EmailVerifiedPage";
import SignUpLogInPage from "./pages/Global/SignUpLogInPage";
import PasswordResetRequestPage from "./pages/Global/PasswordResetRequestPage";
import PasswordResetPage from "./pages/Global/PasswordResetPage";
import AdminSignInPage from "./pages/Admin/AdminSignInPage";

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
        <Route path="admin" element={<AdminSignInPage />}></Route>
      </Route>
    )
  );

  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
