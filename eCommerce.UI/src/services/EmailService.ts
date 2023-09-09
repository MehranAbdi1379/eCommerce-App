import apiClient from "./ApiClient";

class EmailService {
  VerifyEmail(userId: any, token: any) {
    if (token) token = token.split(" ").join("+");
    apiClient
      .put("email/verify-email", { userId, token })
      .then((res) => console.log(res))
      .catch((err) => console.log("not verified"));
  }
  SendPasswordResetEmail(email: any, setPasswordResetEmailSent: any) {
    apiClient
      .get("email/send-password-reset-email", { params: { email } })
      .then((res) => setPasswordResetEmailSent(true))
      .catch((err) => console.log(err));
  }
  ResetPassword(email: any, token: any, newPassword: any) {
    apiClient
      .put("emai/reset-password", { email, token, newPassword })
      .then((res) => console.log(res))
      .then((err) => console.log(err));
  }
}

export default EmailService;
