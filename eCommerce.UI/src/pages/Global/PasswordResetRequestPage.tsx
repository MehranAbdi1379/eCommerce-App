import {
  Container,
  Heading,
  FormControl,
  Input,
  Button,
  Text,
} from "@chakra-ui/react";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { Form } from "react-router-dom";
import EmailService from "../../services/EmailService";

const PasswordResetRequestPage = () => {
  const { register, handleSubmit } = useForm();
  const { SendResetPasswordEmail } = new EmailService();
  const [passwordResetEmailSent, setPasswordResetEmailSent] = useState(false);
  return (
    <Container border={"2px solid gray"} borderRadius={"10px"} padding={"35px"}>
      <Heading fontSize={"2rem"} marginBottom={"0.8em"}>
        Reset Password
      </Heading>
      <Form
        onSubmit={handleSubmit((data) =>
          SendResetPasswordEmail(data.email, setPasswordResetEmailSent)
        )}
      >
        <FormControl marginBottom={"1.3em"}>
          <Input {...register("email")} placeholder="Email"></Input>
        </FormControl>
        <FormControl>
          <Button type="submit">Send Password Reset Email</Button>
        </FormControl>
        {passwordResetEmailSent && (
          <Text color={"red.300"}>Password reset email has been sent.</Text>
        )}
      </Form>
    </Container>
  );
};

export default PasswordResetRequestPage;
