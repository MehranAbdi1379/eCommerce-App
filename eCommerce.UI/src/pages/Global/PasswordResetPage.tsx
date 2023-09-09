import {
  Container,
  Heading,
  FormControl,
  Input,
  Button,
} from "@chakra-ui/react";
import React from "react";
import { Form, useSearchParams } from "react-router-dom";
import EmailService from "../../services/EmailService";
import { useForm } from "react-hook-form";

const PasswordResetPage = () => {
  const { ResetPassword } = new EmailService();
  const [queryParams] = useSearchParams();
  const { register, handleSubmit } = useForm();
  return (
    <Container border={"2px solid gray"} borderRadius={"10px"} padding={"35px"}>
      <Heading fontSize={"2rem"} marginBottom={"0.8em"}>
        Reset Password
      </Heading>
      <Form
        onSubmit={handleSubmit((data) =>
          ResetPassword(
            queryParams.get("email"),
            queryParams.get("token"),
            data.newPassword
          )
        )}
      >
        <FormControl marginBottom={"1.3em"}>
          <Input
            {...register("newPassword")}
            placeholder="New Password"
          ></Input>
        </FormControl>
        <FormControl>
          <Button type="submit">Send Password Reset Email</Button>
        </FormControl>
      </Form>
    </Container>
  );
};

export default PasswordResetPage;
