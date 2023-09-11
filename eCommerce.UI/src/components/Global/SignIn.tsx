import React from "react";
import { useForm } from "react-hook-form";
import { Form, Link, useNavigate } from "react-router-dom";
import UserService from "../../services/UserService";
import {
  Container,
  Heading,
  FormControl,
  Input,
  FormLabel,
  Button,
  Text,
} from "@chakra-ui/react";

const SignInContainer = () => {
  const { handleSubmit: handleSignInSubmit, register: signInRegister } =
    useForm();
  const { SignIn } = new UserService();
  const navigate = useNavigate();

  return (
    <Container>
      <Form
        onSubmit={handleSignInSubmit((data) =>
          SignIn(data.email, data.password, navigate)
        )}
      >
        <FormControl marginBottom={"1.3em"}>
          <Input {...signInRegister("email")} placeholder="Email"></Input>
        </FormControl>
        <FormControl marginBottom={"1.3em"}>
          <FormLabel>
            <Input
              {...signInRegister("password")}
              placeholder="Password"
            ></Input>
          </FormLabel>
        </FormControl>
        <FormControl>
          <Button type="submit">Log In</Button>
        </FormControl>
      </Form>
      <Link to={"/password-reset-request"}>
        <Text marginTop={3} color={"red"}>
          Forgot Password?
        </Text>
      </Link>
    </Container>
  );
};

export default SignInContainer;
