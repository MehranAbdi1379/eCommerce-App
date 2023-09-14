import apiClient from "./ApiClient";
import AuthApiClient from "./AuthApiClient";

class AdminService {
  SignIn(email: any, password: any, navigate: any) {
    apiClient
      .get("user/sign-in", { params: { email, password } })
      .then((res) => {
        if (res.data.role == "admin") {
          localStorage.setItem("token", res.data.token);
          localStorage.setItem("userId", res.data.userId);
          navigate("/admin");
        } else {
          alert("You are not an Admin");
        }
      })
      .catch((err) => console.log(err.data));
  }
}

export default AdminService;
