import { Button } from "@chakra-ui/react";
import AuthApiClient from "../../services/AuthApiClient";

const MainPage = () => {
  return (
    <>
      <Button onClick={() => AuthApiClient().get("user/send-email")}>
        Send Email
      </Button>
    </>
  );
};

export default MainPage;
