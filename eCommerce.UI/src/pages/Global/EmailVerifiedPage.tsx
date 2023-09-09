import React, { useEffect } from "react";
import { useSearchParams } from "react-router-dom";
import EmailService from "../../services/EmailService";

const EmailVerifiedPage = () => {
  const [queryParams] = useSearchParams();
  const { VerifyEmail } = new EmailService();
  useEffect(() => {
    VerifyEmail(queryParams.get("userId"), queryParams.get("token"));
  }, []);

  return (
    <div>
      Email has been verified successfully. Please log in and start using the
      website.
    </div>
  );
};

export default EmailVerifiedPage;
