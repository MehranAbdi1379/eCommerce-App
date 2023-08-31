import apiClient from "./ApiClient";
import AuthApiClient from "./AuthApiClient";

class UserService {
  SignUp(email: string, password: string, navigate: any) {
    apiClient
      .post("user/sign-up", { email, password })
      .then(() => navigate("/email-verification-sent"))
      .catch((err) => console.log(err));
  }
  VerifyEmail(userId: any, token: any) {
    if (token) token = token.split(" ").join("+");
    apiClient
      .put("user/verify-email", { userId, token })
      .then((res) => console.log(res))
      .catch((err) => console.log("not verified"));
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
