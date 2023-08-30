import React, { useEffect } from "react";
import { useSearchParams } from "react-router-dom";
import UserService from "../../services/UserService";

const EmailVerifiedPage = () => {
  const [queryParams] = useSearchParams();
  const { VerifyEmail } = new UserService();
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
