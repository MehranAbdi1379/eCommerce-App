import apiClient from "./ApiClient";

class EmailService {
  VerifyEmail(userId: any, token: any) {
    if (token) token = token.split(" ").join("+");
    apiClient
      .put("email/verify-email", { userId, token })
      .then((res) => console.log(res))
      .catch((err) => console.log("not verified"));
  }
  SendResetPasswordEmail(email: any, setPasswordResetEmailSent: any) {
    apiClient
      .get("email/send-reset-password-email", { params: { email } })
      .then((res) => setPasswordResetEmailSent(true))
      .catch((err) => console.log(err));
  }
  ResetPassword(email: any, token: any, newPassword: any, navigate: any) {
    if (token) token = token.split(" ").join("+");
    apiClient
      .put("email/reset-password", { email, token, newPassword })
      .then((res) => {
        alert("Password has been reset");
        navigate("/");
      })
      .then((err) => console.log(err));
  }
}

export default EmailService;
