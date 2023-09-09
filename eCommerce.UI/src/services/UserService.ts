import apiClient from "./ApiClient";
import AuthApiClient from "./AuthApiClient";

class UserService {
  SignUp(email: string, password: string, navigate: any) {
    apiClient
      .post("user/sign-up", { email, password })
      .then(() => navigate("/email-verification-sent"))
      .catch((err) => console.log(err));
  }

  SignIn(email: string, password: string) {
    apiClient
      .get("user/sign-in", { params: { email, password } })
      .then((res) => {
        localStorage.setItem("token", res.data.token);
        localStorage.setItem("userId", res.data.userId);
      })
      .catch((err) => console.log(err.data));
  }
}

export default UserService;
