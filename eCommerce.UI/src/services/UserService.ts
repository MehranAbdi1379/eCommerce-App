import AuthApiClient from "./AuthApiClient";

class UserService {
  SignUp(email: any, password: any) {
    AuthApiClient()
      .post("user/sign-up", { email, password })
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }
}

export default UserService;
