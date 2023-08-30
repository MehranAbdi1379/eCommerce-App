import {
  Route,
  RouterProvider,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import RootLayout from "./layouts/RootLayout";
import MainPage from "./pages/Global/MainPage";
import SignUpPage from "./pages/Global/SignUpPage";
import SignInPage from "./pages/Global/SignInPage";
import EmailVerificationSentPage from "./pages/Global/EmailVerificationSentPage";
import EmailVerifiedPage from "./pages/Global/EmailVerifiedPage";

function App() {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route>
        <Route element={<RootLayout />}>
          <Route index element={<MainPage />}></Route>
          <Route path="sign-up" element={<SignUpPage />}></Route>
          <Route path="sign-in" element={<SignInPage />}></Route>
          <Route
            path="email-verification-sent"
            element={<EmailVerificationSentPage />}
          ></Route>
          <Route path="email-verified" element={<EmailVerifiedPage />}></Route>
        </Route>
      </Route>
    )
  );

  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
